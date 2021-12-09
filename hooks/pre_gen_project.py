import sys
import re


dns_name = re.sub(r'([a-z0-9])([A-Z])',r'\1-\2', '{{cookiecutter.project_name}}').lower()
             .sub(r'([a-z0-9])([A-Z])',r'\1-\2', '__cookiecutter.project_name__').lower()
             .sub(r'([a-z0-9])([A-Z])',r'\1-\2', '{{cookiecutter.ns_name}}').lower()
             .sub(r'([a-z0-9])([A-Z])',r'\1-\2', '__cookiecutter.ns_name__').lower()