# Technical Test: CNPJ Processing Microservice

## Overview

Develop a C# microservice that integrates with Kafka, PostgreSQL, and Kubernetes. The application should:

- **Consume messages** from a Kafka topic containing records with a CNPJ.
- **Validate the CNPJ** using official format and checksum rules.
- **Persist valid records** in a PostgreSQL database.
- **Republish results**:
  - If the CNPJ is valid, re-publish the record to a "success" Kafka topic.
  - If invalid, publish an error message to a separate "error" Kafka topic.
- **Documentation & Automation**: Include a brief `README.md` and a `Makefile` to streamline common tasks (build, test, deploy).
- **(Desireble) Deploy** the solution on a local Kubernetes cluster (e.g., Minikube, k3s, or any local alternative) using a custom Helm chart.

---

## Requirements

### 1. Kafka Integration

- **Consumer**:
  - Subscribe to an input topic (e.g., `cnpj-input`).
  - Use a robust C# Kafka client library (e.g., [Confluent.Kafka](https://github.com/confluentinc/confluent-kafka-dotnet)).
  - Read and process messages that include a CNPJ field.

- **Producer**:
  - For valid messages, publish to a success topic (e.g., `cnpj-validated`).
  - For invalid messages, publish an error message to an error topic (e.g., `cnpj-error`).

- **Error Handling**:
  - Implement robust error handling and logging to manage problematic messages gracefully.

### 2. CNPJ Validation

- **Validation Logic**:
  - Create a function to validate the CNPJ by checking:
    - The format (correct number of digits and allowed characters).
    - The checksum according to official CNPJ rules.
  - Write unit tests covering:
    - Valid CNPJ numbers.
    - Invalid CNPJ numbers.
    - Edge-case scenarios.

### 3. PostgreSQL Integration

- **Database Persistence**:
  - Connect to a PostgreSQL database.
  - Create a table (e.g., `CnpjRecords`) with at least the following fields:
    - `Id` (Primary Key)
    - `Cnpj` (string)
    - `ValidatedAt` (timestamp)
    - `Status` (values: "Valid" or "Error")
    - Additional fields (e.g., error messages or processing details)
  - Use an ORM (e.g., Entity Framework Core) for data access.


### 4. Repository Documentation & Automation

- **README.md**:
  - Provide brief documentation explaining:
    - The purpose of the module.
    - An architecture overview.
    - Setup instructions including prerequisites.
    - Steps to build, test, and deploy the application.

### 5. (Desirable) Containerization & Deployment

- **Dockerization**:
  - Create a `Dockerfile` to containerize the C# microservice.
  - Ensure the container is optimized for production use.

- **Kubernetes & Helm Chart**:
  - Develop a custom Helm chart that deploys:
    - A Kubernetes Deployment for the C# microservice.
    - A Kubernetes Service to expose the application.
    - ConfigMaps/Secrets to manage environment variables (e.g., Kafka broker addresses, PostgreSQL connection details).
  - Ensure the solution is deployable on a local Kubernetes cluster (e.g., Minikube, k3s).

### 6. Submission Guidelines

- **Repository Structure**:
  - Organize your repository with separate directories for source code, tests, Docker/Helm configurations, and documentation.

- **Code Quality**:
  - Write clean, well-documented code following industry best practices.

- **Testing**:
  - Provide comprehensive unit tests, particularly for the CNPJ validation logic and Kafka message handling.

- **Deployment**:
  - Include clear instructions on deploying the solution on a local Kubernetes cluster using the provided Helm chart and Makefile.

### 7. Bonus Points

- **Advanced Logging & Monitoring**:
  - Integrate a logging framework (e.g., Serilog) for enhanced observability.

- **Docker Compose**:
  - Provide a Docker Compose file to spin up Kafka, PostgreSQL, and your service locally for development.

- **CI/CD Pipeline**:
  - Set up a basic CI/CD pipeline (e.g., using GitHub Actions) to build, test, and package the application automatically.

---

This technical test is designed to evaluate your ability to integrate distributed systems with robust C# coding practices, containerization, and deployment automation. Good luck!