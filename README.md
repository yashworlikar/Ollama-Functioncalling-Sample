# Semantic Kernel Ollama Connector Sample 

## Prerequisites
- Docker
- .NET SDK
- Ollama

## Setup and Installation

### 1. Pull and Run Ollama Container
```bash
# Pull Ollama image
docker pull ollama/ollama

# Run Ollama container
docker run -d -v ollama:/root/.ollama -p 11434:11434 --name ollama ollama/ollama

# Pull Llama3.2 model
docker exec -it ollama ollama pull llama3.2
```

### 2. Run .NET Application
```bash
# Navigate to project directory
dotnet run
```

## Configuration Notes
- Ollama runs locally on port 11434
- Persistent model storage is mapped to the `ollama` volume
- Llama3.2 model is used in this example

## Troubleshooting
- Ensure Docker is running
- Verify Ollama container is active with `docker ps`
- Check network connectivity to localhost:11434

## Console app 
![Running](https://github.com/user-attachments/assets/35cc459b-432e-4cfd-bcec-fdeaa22abd5d)
