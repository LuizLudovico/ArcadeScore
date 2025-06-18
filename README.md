
# 🎮 ArcadeScore API

Uma API RESTful em .NET 6 desenvolvida para registrar e analisar pontuações de jogadores em partidas de arcade. O objetivo do projeto é demonstrar uma estrutura limpa e escalável com boas práticas, como DDD, injeção de dependência e uso de repositório em memória.

---

## 🚀 Tecnologias Utilizadas

- ASP.NET Core 6 (Minimal Hosting Model)
- C# 10
- Swagger/OpenAPI
- Injeção de dependência (DI)
- Arquitetura DDD em camadas
- Repositório in-memory
- RESTful API

---

## 📂 Estrutura de Pastas

```
ArcadeScore/
├── Application          # Web API + Controllers + Program.cs
├── Domain               # Entidades e interfaces
├── Service              # Implementação de repositórios e lógica
├── CrossCutting         # Injeção de dependência centralizada
└── ArcadeScore.sln      # Solução principal
```

---

## ✅ Funcionalidades da API

| Verbo  | Endpoint                        | Descrição                                     |
|--------|----------------------------------|-----------------------------------------------|
| POST   | `/api/Pontuacao`                | Registra nova pontuação de jogador            |
| GET    | `/api/Pontuacao/ranking`        | Lista os 10 jogadores com maior pontuação     |
| GET    | `/api/Pontuacao/{jogador}`      | Estatísticas completas do jogador informado   |
| PUT    | `/api/Pontuacao/{id}`           | Atualiza os dados de uma pontuação existente  |
| DELETE | `/api/Pontuacao/{id}`           | Remove uma pontuação existente                |

---

## ▶️ Como Executar Localmente

1. **Clone o repositório:**
   ```bash
   git clone https://github.com/LuizLudovico/ArcadeScore.git
   ```

2. **Abra a solução no Visual Studio 2022 ou superior**

3. **Execute o projeto `Arcade.Application`**

4. **Acesse o Swagger:**
   ```
   https://localhost:{PORT}/swagger
   ```

---

## 🧪 Exemplos de Requisições

### 📌 POST `/api/Pontuacao` — Registrar nova pontuação

```http
POST /api/Pontuacao
Content-Type: application/json

{
  "jogador": "Luiz",
  "pontos": 1500,
  "dataPartida": "2025-06-18T15:30:00"
}
```

### 📌 GET `/api/Pontuacao/ranking` — Top 10 jogadores com maior pontuação

```http
GET /api/Pontuacao/ranking
```

**Resposta esperada:**
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

### 📌 GET `/api/Pontuacao/{jogador}` — Estatísticas de um jogador

```http
GET /api/Pontuacao/Luiz
```

**Resposta esperada:**
```json
{
  "jogador": "Luiz",
  "partidasJogadas": 5,
  "mediaPontuacao": 1320,
  "maiorPontuacao": 1500,
  "menorPontuacao": 1200,
  "recordesBatidos": 2,
  "tempoDeJogo": "10 dias"
}
```

### 📌 PUT `/api/Pontuacao/{id}` — Atualizar uma pontuação existente

```http
PUT /api/Pontuacao/b3fd0b65-1c7e-47e2-810f-b2078372e927
Content-Type: application/json

{
  "jogador": "Luiz",
  "pontos": 1600,
  "dataPartida": "2025-06-18T15:30:00"
}
```

**Resposta esperada:**
```json
{
  "jogador": "Luiz",
  "pontos": 1600,
  "dataPartida": "2025-06-18T15:30:00"
}
```

### 📌 DELETE `/api/Pontuacao/{id}` — Remover uma pontuação

```http
DELETE /api/Pontuacao/b3fd0b65-1c7e-47e2-810f-b2078372e927
```

**Resposta esperada:**
```
204 No Content
```

---

## 🧠 O que foi considerado no desenvolvimento

- Separação de responsabilidades clara entre camadas
- Boas práticas REST com HTTP Status apropriados
- API testável e desacoplada usando DI
- Repositório de dados simulado com lista em memória
- Simples de entender, mas facilmente extensível

---

## 📌 Autor

**Luiz Ludovico Machado**  
Candidato à vaga .NET | GitHub: [@LuizLudovico](https://github.com/LuizLudovico)

---

> Projeto construído para fins de avaliação técnica — 2025 🚀
