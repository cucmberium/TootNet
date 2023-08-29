import glob
import json
import logging
import os
import re
from typing import Any

IGNORE_FILES = ["oauth.md", "push.md", "streaming.md"]


def main(doc_dir: str, output_dir: str, logger: logging.Logger) -> None:
    logger.info("generate template from mastodon documentation")

    for path in sorted(glob.glob(os.path.join(doc_dir, "content", "en", "methods", "*.md"))):
        if any(ignore_file in path for ignore_file in IGNORE_FILES):
            continue

        logger.info(f"target_path: {path}")

        name = os.path.basename(path).replace(".md", "")
        logger.info(f"api: {name}")

        contents: list[str]
        if name == "filters":
            contents = open(path, encoding="utf-8").read().split("\n### ")
        else:
            contents = open(path, encoding="utf-8").read().split("\n## ")
        contents = [x.strip().strip("-").strip() for x in contents][1:-1]

        methods = []
        for content in contents:
            method: dict[str, Any] = {}

            # region extract http method and path
            http_match = re.search(r"```http\n(POST|GET|PATCH|PUT|DELETE) (.+?)( HTTP/1.1)?\n```", content)
            if not http_match:
                raise ValueError("no http method found")
            method["path"] = http_match.group(2)
            method["method"] = http_match.group(1)
            # endregion

            # region extract description
            description_match = re.search(r"(.+?) {", content)
            if not description_match:
                raise ValueError("no description detected")
            description = description_match.group(1)
            if "DEPRECATED" in description or "REMOVED" in description:
                continue
            method["description"] = description
            # endregion

            # region extract return entity type
            method["return"] = ""
            return_entity_text = [x for x in content.split("\n") if x.startswith("**Returns:**")][0].replace(
                "**Returns:** ", ""
            )
            if "Array of" in return_entity_text:
                method["return"] = "Array "
            return_entity_match = re.search(r".*?\[([^]]+)", return_entity_text)
            if return_entity_match:
                method["return"] += return_entity_match.group(1)
            elif "Empty" in return_entity_text or "empty" in return_entity_text or "n/a" in return_entity_text:
                method["return"] += "Empty"
            elif "String" in return_entity_text:
                method["return"] += "String"
            else:
                method["return"] += "Other"
            # endregion

            # region extract parameters
            method["parameters"] = []
            for parameter_type in ["Path", "Form data", "Query"]:
                parameters_match = re.search(rf"##### {parameter_type} parameters\n\n(.+?)\n\n####", content, re.DOTALL)
                if not parameters_match:
                    continue

                parameter_matches = re.findall(
                    r"([?P<name>a-zA-Z0-9_\[\]:]+) *\n: ?(?P<required>{{<required>}})? (?P<type>.+)",
                    parameters_match.group(1),
                )
                for parameter in parameter_matches:
                    method["parameters"].append(
                        {
                            "name": parameter[0],
                            "type": parameter[2]
                            .replace("**Internal parameter.**", "Integer. ")
                            .replace("Array of ", "Array ")
                            .split(".")[0],
                            "required": parameter[1] == "{{<required>}}",
                        }
                    )
            # endregion

            logger.info(f"method: {json.dumps(method)}")

            methods.append(method)

        if not methods:
            continue

        with open(os.path.join(output_dir, f"{name}.json"), "w") as fout:
            print(json.dumps(methods, indent=4), file=fout)

    logger.info("complete!")
