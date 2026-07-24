# Docker Essentials

## 1. Introduction to Docker

Docker is an open-source platform used for containerization. It allows developers to package applications along with all their required dependencies into containers, ensuring consistent execution across different systems.

---

## 2. Key Features of Docker

- Lightweight containers
- Quick deployment
- Cross-platform compatibility
- Easy application portability
- Scalable architecture
- Application isolation
- Better resource management

---

## 3. Docker Components

The Docker platform consists of the following components:

- Docker Client
- Docker Daemon
- Docker Engine
- Docker Registry (Docker Hub)
- Docker Images
- Docker Containers

---

## 4. Common Docker Commands

### Display Docker Version

```bash
docker --version
```

### Download an Image

```bash
docker pull ubuntu
```

### Show Available Images

```bash
docker images
```

### Start a Container

```bash
docker run ubuntu
```

### Run a Container in Detached Mode

```bash
docker run -d nginx
```

### View Running Containers

```bash
docker ps
```

### View All Containers

```bash
docker ps -a
```

### Stop a Running Container

```bash
docker stop <container-id>
```

### Delete a Container

```bash
docker rm <container-id>
```

### Delete an Image

```bash
docker rmi <image-id>
```

---

## 5. Docker Run Options

### Interactive Mode

```bash
docker run -it ubuntu
```

### Detached Mode

```bash
docker run -d nginx
```

### Assign a Custom Name

```bash
docker run --name mycontainer ubuntu
```

### Map Container Ports

```bash
docker run -p 8080:80 nginx
```

---

## 6. Docker Images

A Docker image is a read-only template used to create one or more containers.

### Categories of Images

- Base Image
- Parent Image
- Custom Image

Docker images are built using multiple layers, which improves storage efficiency and speeds up image reuse.

---

## 7. Dockerfile

A Dockerfile is a script containing instructions used to build Docker images automatically.

Example:

```dockerfile
FROM ubuntu
RUN apt update
CMD ["bash"]
```

---

## 8. Docker Compose

Docker Compose helps manage applications that require multiple containers.

Compose configuration is written using YAML.

Example:

```yaml
version: "3"

services:
  web:
    image: nginx
```

Useful commands:

```bash
docker-compose up
docker-compose down
```

---

## 9. Docker Engine

Docker Engine includes:

- Docker CLI
- Docker Daemon
- REST API

---

## 10. Docker Storage

Docker uses volumes to store persistent application data.

Create a volume:

```bash
docker volume create myvolume
```

Display available volumes:

```bash
docker volume ls
```

---

## 11. Docker Networking

Docker provides several built-in network drivers:

- Bridge
- Host
- None

Useful commands:

```bash
docker network ls
```

```bash
docker network inspect bridge
```

```bash
docker network create mynetwork
```

---

## 12. Container Orchestration

Container orchestration simplifies:

- Deployment
- Scaling
- Load balancing
- Monitoring
- Container management

---

## 13. Kubernetes

Kubernetes is a powerful orchestration platform used for managing containerized applications.

### Main Features

- Automatic scaling
- Load balancing
- Self-healing
- Rolling updates
- Automated deployments

---

## Conclusion

Docker makes application deployment simple through containerization. When combined with Docker Compose and Kubernetes, it provides a reliable, scalable, and portable environment for modern software development.