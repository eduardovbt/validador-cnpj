#!/bin/bash

# Aguardar Kafka estar pronto
echo "Aguardando Kafka iniciar..."
until docker-compose exec kafka kafka-topics --bootstrap-server kafka:29092 --list >/dev/null 2>&1; do
  echo "Kafka não está pronto, aguardando..."
  sleep 5
done

# Criar o tópico
echo "Kafka está pronto. Criando o tópico..."
docker-compose exec kafka kafka-topics --bootstrap-server kafka:29092 --create --topic cnpj-validate-topic --partitions 1 --replication-factor 1
echo "Tópico 'cnpj-validate-topic' criado com sucesso!"
