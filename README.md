# PasswordGuard V2

Analisador de força de senhas desenvolvido em C# com .NET 10, com foco em fundamentos de segurança, detecção de padrões previsíveis e avaliação heurística de senhas.

## Sobre o projeto

O PasswordGuard é uma aplicação de console que analisa características de uma senha e fornece uma avaliação estimada de sua força. O objetivo é identificar comportamentos previsíveis, avaliar a composição da senha e apresentar recomendações para melhorias.

## Funcionalidades

- Entrada de senha com caracteres mascarados no terminal.
- Análise de comprimento.
- Identificação de letras maiúsculas e minúsculas, números e símbolos.
- Detecção de padrões comuns e palavras previsíveis.
- Identificação de sequências crescentes e decrescentes.
- Detecção de caracteres repetidos consecutivamente.
- Estimativa teórica de entropia.
- Sistema de pontuação de 0 a 100.
- Classificação em cinco níveis de força.
- Recomendações de segurança personalizadas.

## Classificação

| Pontuação | Classificação |
|---|---|
| 0–29 | Muito fraca |
| 30–49 | Fraca |
| 50–69 | Razoável |
| 70–89 | Forte |
| 90–100 | Muito forte |

## Tecnologias utilizadas

- C#
- .NET 10
- Programação orientada a objetos
- Git e GitHub

## Como executar

É necessário ter o SDK .NET instalado.

Clone o repositório:

```bash
git clone https://github.com/GuilhermeCarv24/PasswordGuard.git
```

Entre na pasta do projeto:

```bash
cd PasswordGuard
```

Execute:

```bash
dotnet run
```

## Conceitos aplicados

- Lógica de programação
- Orientação a objetos
- Métodos e classes
- Manipulação de strings
- Condicionais e loops
- Análise heurística
- Segurança de senhas
- Tratamento de entrada no console

## Limitações de segurança

O PasswordGuard utiliza heurísticas próprias para estimar a força de uma senha. A pontuação e a entropia são estimativas educativas e não representam garantia de resistência a ataques.

A ferramenta não consulta bases de senhas vazadas, não calcula tempo real de quebra e não substitui gerenciadores de senhas ou mecanismos profissionais de avaliação.

As senhas são analisadas localmente pela aplicação e não são enviadas para servidores externos.

## Desenvolvido por

Guilherme Carvalho

Projeto desenvolvido para estudos de programação, cibersegurança e evolução prática em C# e .NET.