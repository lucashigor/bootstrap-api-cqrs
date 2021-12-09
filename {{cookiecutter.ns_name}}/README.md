# Introdução
{{cookiecutter.project_name}}

# Configuração de banco
- Caso sua API não use banco de dados, **apague** a pasta flyway/*
- Configure o nome do banco em ./flyway/conf/flyway.conf -> `databaseName=DATABASE_NAME_NOT_SET`

# Pipelines
- Pedir configuração dos pipes de CI e CD apontando para o seu pipe de acordo com a seguinte documentação 