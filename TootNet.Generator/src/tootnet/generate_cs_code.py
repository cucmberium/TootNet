import logging
import glob
import json
import os


HEADER = """
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TootNet.Internal;
using TootNet.Objects;

namespace TootNet.Rest
{{
    public class {class_name} : ApiBase
    {{
        internal {class_name}(Tokens e) : base(e) {{ }}
""".strip(
    "\n"
)

EXPR_FUNC = """
        public Task{return_type} {method_name}Async(params Expression<Func<string, object>>[] parameters)
        {{
            return Tokens.AccessApiAsync<{return_type}>(MethodType.{method_type}, "{route}", Utils.ExpressionToDictionary(parameters){api_version});
        }}
""".strip(
    "\n"
)
EXPR_PR_FUNC = """
        public Task{return_type} {method_name}Async(params Expression<Func<string, object>>[] parameters)
        {{
            return Tokens.AccessParameterReservedApiAsync<{return_type}>(MethodType.{method_type}, "{route}", "{reserved}", Utils.ExpressionToDictionary(parameters){api_version});
        }}
""".strip(
    "\n"
)

DIC_FUNC = """
        public Task{return_type} {method_name}Async(IDictionary<string, object> parameters)
        {{
            return Tokens.AccessApiAsync<{return_type}>(MethodType.{method_type}, "{route}", parameters{api_version});
        }}
""".strip(
    "\n"
)
DIC_PR_FUNC = """
        public Task{return_type} {method_name}Async(IDictionary<string, object> parameters)
        {{
            return Tokens.AccessParameterReservedApiAsync<{return_type}>(MethodType.{method_type}, "{route}", "{reserved}", parameters{api_version});
        }}
""".strip(
    "\n"
)

FOOTER = """
    }}
}}
""".strip(
    "\n"
)

INDENT = "        "

CSHARP_TYPES = ["int", "uint", "long", "ulong", "float", "double", "char", "bool", "string"]


def snake_to_pascal(text):
    return "".join(word.capitalize() for word in text.split("_"))


def write_cs_code(input_path: str, output_path: str, logger: logging.Logger) -> None:
    name = os.path.basename(input_path).replace(".json", "")

    class_name = snake_to_pascal(name)

    with open(input_path) as fin, open(output_path, "w") as fout:
        fout.write(HEADER.format(class_name=class_name).lstrip() + "\n")

        for method in json.load(fin):
            fout.write("\n")

            # write documents
            fout.write(f"{INDENT}/// <summary>\n")
            fout.write(f"{INDENT}/// <para>{method['description']}</para>\n")
            fout.write(f"{INDENT}/// <para>Available parameters:</para>\n")
            if len(method["parameters"]) == 0:
                fout.write(f"{INDENT}/// <para>- No parameters available in this method.</para>\n")
            else:
                for parameter in method["parameters"]:
                    ptype = parameter["type"].lower()
                    pname = parameter["name"].replace(":", "")
                    popt = "required" if parameter["required"] else "optional"
                    fout.write(f"{INDENT}/// <para>- <c>{ptype}</c> {pname} ({popt})</para>\n")
            fout.write(f"{INDENT}/// </summary>\n")

            fout.write(f'{INDENT}/// <param name="parameters">The parameters.</param>\n')

            fout.write(f"{INDENT}/// <returns>\n")
            retd: str
            if method["return"].startswith("Array "):
                retd = "list of " + method["return"].replace("Array ", "").lower()
            else:
                retd = method["return"].lower()
            fout.write(f"{INDENT}/// <para>The task object representing the asynchronous operation.</para>\n")
            fout.write(f"{INDENT}/// <para>The Result property on the task object returns the {retd} object.</para>\n")
            fout.write(f"{INDENT}/// </returns>\n")

            # extract method info
            return_type = method["return"].split(" ")[-1]
            if return_type.lower() in CSHARP_TYPES:
                return_type = return_type.lower()
            if method["return"].startswith("Array "):
                if any(["since_id" == x["name"] for x in method["parameters"]]):
                    return_type = "Linked<" + return_type + ">"
                else:
                    return_type = "IEnumerable<" + return_type + ">"
            if return_type == "Empty":
                return_type = ""
            else:
                return_type = "<" + return_type + ">"

            method_name = snake_to_pascal(method["path"].split("/")[-1].replace(":", ""))
            if method_name == class_name:
                method_name = snake_to_pascal(method["method"])

            method_type = snake_to_pascal(method["method"])

            route = method["path"].replace("/api/v1/", "")
            api_version = ""
            if "/api/v2/" in method["path"]:
                route = method["path"].replace("/api/v2/", "")
                api_version = ', apiVersion: "v2"'
            route = "/".join(["{" + x.replace(":", "") + "}" if x.startswith(":") else x for x in route.split("/")])

            reserved = ""
            if ":" in method["path"]:
                reserved = [x["name"].replace(":", "") for x in method["parameters"] if x["name"].startswith(":")][0]

            # write expr method
            expr_func_str = EXPR_FUNC
            if ":" in method["path"]:
                expr_func_str = EXPR_PR_FUNC
            fout.write(
                expr_func_str.format(
                    return_type=return_type,
                    method_name=method_name,
                    method_type=method_type,
                    route=route,
                    api_version=api_version,
                    reserved=reserved,
                )
            )
            fout.write("\n\n")

            # write inheritdoc
            fout.write(f'{INDENT}/// <inheritdoc cref="{method_name}Async(Expression{{Func{{string, object}}}}[])"/>')
            fout.write("\n")

            # write dic method
            dic_func_str = DIC_FUNC
            if ":" in method["path"]:
                dic_func_str = DIC_PR_FUNC
            fout.write(
                dic_func_str.format(
                    return_type=return_type,
                    method_name=method_name,
                    method_type=method_type,
                    route=route,
                    api_version=api_version,
                    reserved=reserved,
                )
            )
            fout.write("\n")

        print(FOOTER.format(), file=fout)


def main(template_dir: str, output_dir: str, logger: logging.Logger) -> None:
    logger.info("generate template from mastodon documentation")
    for input_path in sorted(glob.glob(os.path.join(template_dir, "*.json"))):
        name = os.path.basename(input_path).replace(".json", "")

        output_path = os.path.join(output_dir, f"{snake_to_pascal(name)}.cs")

        write_cs_code(input_path, output_path, logger)

    logger.info("complete!")
