
# 🎮 ArcadeScore API

Uma API RESTful em .NET 6 desenvolvida para registrar e analisar pontuações de jogadores em partidas de arcade. O objetivo do projeto é demonstrar uma estrutura limpa e escalável com boas práticas, como DDD, injeção de dependência e repositório em memória.

---

## 🚀 Tecnologias Utilizadas

- ASP.NET Core 6
- C# 10
- Swagger / OpenAPI
- Injeção de Dependência (DI)
- Arquitetura em camadas (DDD)
- Repositório In-Memory
- RESTful API

---

## 📂 Estrutura de Pastas

```
ArcadeScore/
├── Application          # Web API + Controllers + Program.cs
├── Domain               # Entidades, DTOs e interfaces de repositório
├── Service              # Serviços e repositórios concretos
├── CrossCutting         # Configuração de injeção de dependência
└── ArcadeScore.sln      # Solução principal
```

---

## ✅ Endpoints da API

| Verbo  | Endpoint                                | Descrição                                      |
|--------|-----------------------------------------|------------------------------------------------|
| POST   | `/api/Pontuacao`                        | Registra nova pontuação                        |
| GET    | `/api/Pontuacao/ranking`                | Retorna os 10 jogadores com maior pontuação    |
| GET    | `/api/Pontuacao/estatisticas/{jogador}` | Retorna estatísticas completas do jogador      |
| PUT    | `/api/Pontuacao/{id}`                   | Atualiza uma pontuação existente               |
| DELETE | `/api/Pontuacao/{id}`                   | Remove uma pontuação                           |

---

## ▶️ Como Executar Localmente

1. **Clone o repositório**
   ```bash
   git clone https://github.com/LuizLudovico/ArcadeScore.git
   ```

2. **Abra no Visual Studio 2022 ou superior**

3. **Execute o projeto `Arcade.Application` (API)**

4. **Acesse o Swagger:**
   ```
   http://localhost:5089/swagger/index.html
   ```

---

## 🧪 Exemplos de Requisições

### 📌 POST `/api/Pontuacao`
```json
{
  "jogador": "Luiz",
  "pontos": 1500,
  "dataPartida": "2025-06-18T15:30:00"
}
```

### 📌 GET `/api/Pontuacao/ranking`
```json
[
  {
    "id": "b3fd0b65-1c7e-47e2-810f-b2078372e927",
    "jogador": "Luiz",
    "pontos": 1500,
    "dataPartida": "2025-06-18T15:30:00"
  }
]
```

### 📌 GET `/api/Pontuacao/estatisticas/Luiz`
```json
{
  "jogador": "Luiz",
  "partidasJogadas": 5,
  "mediaPontuacao": 1320,
  "maiorPontuacao": 1500,
  "menorPontuacao": 1200,
  "vezesRecorde": 2,
  "tempoQueJoga": "2 meses"
}
```

### 📌 PUT `/api/Pontuacao/{id}`
```json
{
  "jogador": "Luiz",
  "pontos": 1600,
  "dataPartida": "2025-06-20T14:00:00"
}
```

### 📌 DELETE `/api/Pontuacao/{id}`

Resposta:
```
204 No Content
```

---

## 🧠 Considerações Técnicas

- Organização em camadas respeitando o DDD
- Uso de DI com baixo acoplamento
- Lógica de estatísticas centralizada no serviço
- Repositório de dados em memória simulado (InMemory)
- Código limpo, comentado e preparado para extensão futura

---

## 📌 Autor

**Luiz Ludovico Machado**  
Candidato à vaga .NET | GitHub: [@LuizLudovico](https://github.com/LuizLudovico)

---

> Projeto desenvolvido para avaliação técnica - 2025 🚀
