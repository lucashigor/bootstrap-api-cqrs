import sys
import re


dns_name = re.sub(r'([a-z0-9])([A-Z])',r'\1-\2', '{{cookiecutter.project_name}}').lower()