
# PasswordGuard 🔐

**PasswordGuard** é uma aplicação de auditoria de senhas desenvolvida em C# e .NET 10.0.

O projeto analisa características de senhas, identifica padrões previsíveis e apresenta uma classificação acompanhada de recomendações para melhorar sua qualidade.

## Funcionalidades

- Análise do comprimento da senha.
- Identificação de letras maiúsculas e minúsculas.
- Identificação de números e símbolos.
- Detecção de padrões previsíveis.
- Identificação de caracteres repetidos.
- Detecção de sequências consecutivas.
- Sistema de pontuação de 0 a 6.
- Classificação em Fraca, Razoável ou Forte.
- Recomendações automáticas de melhoria.

## 🛠️ Tecnologias utilizadas

- C#
- .NET 10.0
- Visual Studio Code

## 📂 Estrutura do projeto

```text
PasswordGuard/
├── Program.cs
├── AnalisadorSenha.cs
├── ResultadoAnalise.cs
├── PasswordGuard.csproj
└── README.md
```

## ▶️ Como executar

1. Instale o .NET 10 SDK.
2. Clone este repositório:

```bash
git clone https://github.com/GuilhermeCarv24/PasswordGuard.git
```

3. Entre na pasta:

```bash
cd PasswordGuard
```

4. Execute o projeto:

```bash
dotnet run
```

## Como funciona

O PasswordGuard utiliza regras heurísticas para analisar características da senha.

A pontuação considera comprimento, variedade de caracteres e penalidades por padrões previsíveis, repetições e sequências.

A classificação é dividida em:

| Pontuação | Classificação |
|---|---|
| 0 a 2 | Fraca |
| 3 a 4 | Razoável |
| 5 a 6 | Forte |

## 🔒 Privacidade e limitações

- A aplicação não armazena as senhas analisadas.
- A análise é realizada localmente.
- A pontuação é educativa e heurística, não representa uma garantia de segurança.
- O projeto não substitui um gerenciador de senhas ou uma avaliação especializada.

## 🎯 Objetivo do projeto

Este projeto foi desenvolvido com o objetivo de praticar programação em C#, orientação a objetos, lógica de programação e conceitos fundamentais de segurança da informação.

## Melhorias futuras

- Interface gráfica.
- Testes automatizados.
- Detecção mais avançada de padrões.
- Integração com serviços de verificação de senhas comprometidas, preservando a privacidade.

---

Desenvolvido por **Guilherme Carvalho**.
