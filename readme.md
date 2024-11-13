# Workload Identity in Radix

In this workshop we will explore [Radix Workload Identity](https://www.radix.equinor.com/guides/workload-identity/), and how we can use it in our applications to access protected Azure resources without the use of long-lived client secrets or passwords.

We will perform the following tasks:
- Access files in an Azure Storage Blob Container, and connect to a Azure SQL database to query data.
- Run database migration scripts using [Radix CI/CD sub-pipelines](https://www.radix.equinor.com/guides/sub-pipeline/)
- Mount secrets from Azure Key Vault as environment variables.

[How does Workload Identity work in Radix](docs/workloadidentity/readme.md)

## Prerequisites

We recommend using VS Code with [Dev Containers](https://code.visualstudio.com/docs/devcontainers/containers) or [GitHub Codespaces](https://docs.github.com/en/codespaces/overview) for this workshop.

- Dev Containers is an [extension](https://code.visualstudio.com/docs/devcontainers/containers) to [VS Code](https://code.visualstudio.com/docs/setup/setup-overview) and requires [Docker Desktop](https://www.docker.com/products/docker-desktop/).
- GitHub Codespaces can be run in the browser or in VS Code with the the GitHub Codespaces [extension](https://marketplace.visualstudio.com/items?itemName=GitHub.codespaces).


## Steps

Setup:
- [Configure GitHub reposistory](docs/create_repository.md)
- [Configure application in Radix Playground](docs/configure_radix_application.md)


Workload Identity in application:
- [Configure Workload Identity](docs/configure-workload-identity.md)
- [Configure Azure SQL Database](docs/configure-azure-sql.md)
- [Configure web page with movies to access SQL database](docs/configure-page-sqlconnection.md)
- [Configure web page with movies to access Storage Account](docs/configure-page-storageaccount.md)

Workload Identity in Radix sub-pipelines:
- [Configure Workload Identity for sub-pipeline](docs/pipeline-configure-workload-identity.md)

Workload Identity with Azure Key Vault:
- [Configure Workload Identity for Azure Key Vault](/docs/keyvault-workload-identity.md)