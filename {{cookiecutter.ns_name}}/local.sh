docker build -t {{cookiecutter.ns_name}}:1.0.0 .

docker tag {{cookiecutter.ns_name}}:1.0.0 localhost:5005/{{cookiecutter.ns_name}}:1.0.0

docker push localhost:5005/{{cookiecutter.ns_name}}:1.0.0