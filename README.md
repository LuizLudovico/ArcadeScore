
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

| Verbo | Endpoint                        | Descrição                                     |
|-------|----------------------------------|-----------------------------------------------|
| POST  | `/api/Pontuacao`                | Registra nova pontuação de jogador            |
| GET   | `/api/Pontuacao/ranking`        | Lista os 10 jogadores com maior pontuação     |
| GET   | `/api/Pontuacao/{jogador}`      | Estatísticas completas do jogador informado   |

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
   https://localhost:xxxx/swagger
   ```

---

## 🧪 Exemplo de Requisição POST

```json
POST /api/Pontuacao
{
  "jogador": "Luiz",
  "pontos": 1500,
  "dataPartida": "2025-06-18T15:30:00"
}
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
