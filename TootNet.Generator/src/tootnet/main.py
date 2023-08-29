import argparse
import logging
from typing import Any

from generate_cs_code import main as generate_cs_code_main
from generate_template import main as generate_template_main


def get_logger(debug: bool = False) -> logging.Logger:
    logger = logging.getLogger(__name__)
    handler = logging.StreamHandler()
    if debug:
        logger.setLevel(logging.DEBUG)
        handler.setLevel(logging.DEBUG)
    else:
        logger.setLevel(logging.INFO)
        handler.setLevel(logging.INFO)
    handler.setFormatter(
        logging.Formatter(fmt="%(asctime)s [%(levelname)s] %(message)s", datefmt="%Y-%m-%d %H:%M:%S %z")
    )
    logger.addHandler(handler)
    return logger


def generate_template(args: Any) -> None:
    generate_template_main(args.doc_dir, args.output_dir, get_logger())


def generate_cs_code(args: Any) -> None:
    generate_cs_code_main(args.template_dir, args.output_dir, get_logger())


def main() -> None:
    parser = argparse.ArgumentParser(prog="tootnet", description="tootnet generator", add_help=True)
    subparsers = parser.add_subparsers()

    parser_generate_template = subparsers.add_parser("generate_template", help="generate template")
    parser_generate_template.add_argument(
        "-d", "--doc-dir", required=True, type=str, help="dir to mastodon documentation"
    )
    parser_generate_template.add_argument(
        "-o", "--output-dir", required=True, type=str, help="output dir of api template"
    )
    parser_generate_template.set_defaults(handler=generate_template)

    parser_generate_cs_code = subparsers.add_parser("generate_cs_code", help="generate csharp code from template")
    parser_generate_cs_code.add_argument("-t", "--template-dir", required=True, type=str, help="dir to template")
    parser_generate_cs_code.add_argument(
        "-o", "--output-dir", required=True, type=str, help="output dir of csharp code"
    )
    parser_generate_cs_code.set_defaults(handler=generate_cs_code)

    args = parser.parse_args()
    if hasattr(args, "handler"):
        args.handler(args)
    else:
        parser.print_help()


if __name__ == "__main__":
    main()
