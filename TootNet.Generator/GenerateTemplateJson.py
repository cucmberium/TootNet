import os
import re
import glob
import json


IGNORE_FILES = [
    "push.md",
    "streaming.md"
]


def main(base_path):
    results = []
    for path in sorted(glob.glob(os.path.join(base_path, "*.md"))):
        if any(ignore_file in path for ignore_file in IGNORE_FILES):
            continue

        name = os.path.basename(path).replace(".md", "")
        contents = open(path, encoding="utf-8").read().split("\n## ")
        contents = [x.strip().strip("-").strip() for x in contents if not x.startswith("See also") and not x.startswith("---")]
        
        methods = []
        for content in contents:
            method = {
                "summary": "",
                "method": "",
                "path": "",
                "return": "",
                "parameters": []
            }

            summary_match = re.search(r'(.+?) {', content)
            if not summary_match:
                raise ValueError()
            summary = summary_match.group(1)
            if "DEPRECATED" in summary or "REMOVED" in summary:
                continue
            method["summary"] = summary

            http_match = re.search(r'```http\n(POST|GET|PATCH|PUT|DELETE) (.+?)( HTTP/1.1)?\n```', content)
            if not http_match:
                raise ValueError()
            method["method"] = http_match.group(1)
            method["path"] = http_match.group(2)
            
            returns_text = [x for x in content.split("\n") if x.startswith("**Returns:**")][0].replace("**Returns:** ", "")
            if "Array of" in returns_text:
                method["return"] = "Array "
            returns_entity_match = re.search(r'.*?\[([^\]]+)', returns_text)
            if returns_entity_match:
                method["return"] += returns_entity_match.group(1)
            elif "Empty" in returns_text or "empty" in returns_text or "n/a" in returns_text:
                method["return"] += "Empty"
            elif "String" in returns_text:
                method["return"] += "String"
            else:
                method["return"] += "Other"

            path_parameters_section = re.search(r'##### Path parameters\n\n(.+?)\n\n####', content, re.DOTALL)
            if path_parameters_section:
                parameters = re.findall(r'([?P<name>a-zA-Z0-9_\[\]\:]+)\n: ?(?P<required>{{<required>}})? (?P<type>.+)', path_parameters_section.group(1))
                for param in parameters:
                    method["parameters"].append({
                        "name": param[0],
                        "type": param[2].replace("**Internal parameter.**", "Integer. ").replace("Array of ", "Array ").split('.')[0],
                        "required": param[1] == "{{<required>}}"
                    })

            form_data_parameters_section = re.search(r'##### Form data parameters\n\n(.+?)\n\n####', content, re.DOTALL)
            if form_data_parameters_section:
                parameters = re.findall(r'([?P<name>a-zA-Z0-9_\[\]\:]+)\n: ?(?P<required>{{<required>}})? (?P<type>.+)', form_data_parameters_section.group(1))
                for param in parameters:
                    method["parameters"].append({
                        "name": param[0],
                        "type": param[2].replace("**Internal parameter.**", "Integer. ").replace("Array of ", "Array ").split('.')[0],
                        "required": param[1] == "{{<required>}}"
                    })

            query_parameters_section = re.search(r'##### Query parameters\n\n(.+?)\n\n####', content, re.DOTALL)
            if query_parameters_section:
                parameters = re.findall(r'([?P<name>a-zA-Z0-9_\[\]\:]+)\n: ?(?P<required>{{<required>}})? (?P<type>.+)', query_parameters_section.group(1))
                for param in parameters:
                    method["parameters"].append({
                        "name": param[0],
                        "type": param[2].replace("**Internal parameter.**", "Integer. ").replace("Array of ", "Array ").split('.')[0],
                        "required": param[1] == "{{<required>}}"
                    })

            methods.append(method)
                    
        results.append({"name": name, "methods": methods})

    print(json.dumps(results, indent=4))


if __name__ == "__main__":
    # if len(sys.argv) < 2:
    #     path = sys.stdin.readline().strip()
    # else:
    #     path = sys.argv[1].strip()
    path = r"D:\Users\cucmberium\Downloads\documentation-master\content\en\methods"
    main(path)
