
# Cookiecutter Api's
[![#](https://img.shields.io/badge/.netc-v5.0-green)](#)

Esse cookiecutter é um gerador de projeto base para as novas APIs.

## ⚙️ Geração do esqueleto do projeto
### Instalação do cookiecutter obrigatória
#### Homebrew (macOS)
```
brew install cookiecutter
```
#### pip (Windows)

Instalar o Python (Windows x86-64 executable installer) => https://www.python.org/downloads/release/python-386/

Colocar na variável de ambiente no PATH %APPDATA%\Python\Python3x\Scripts (Local onde instalou o Python)

```
pip install cookiecutter
```
#### pip
```
pip install cookiecutter
```
#### Ubuntu
```
sudo apt-get install cookiecutter
```

## Instalação
```
cookiecutter https://github.com/lucashigor/bootstrap-api-cqrs.git
ou
cookiecutter git@github.com:lucashigor/bootstrap-api-cqrs.git
```

## Exemplo, aperte enter após cada pergunta
```
$cookiecutter https://github.com/lucashigor/bootstrap-api-cqrs.git
project_name [EX: BootstrapApi]: TestApi
ns_name [EX: bootstrap-api]: test-api
 [SUCCESS]:Projeto criado, bom trabalho!
```