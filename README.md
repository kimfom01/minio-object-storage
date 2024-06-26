# Minio Object Storage (self hosted)

This is a docker compose config for locally hosted [minio](https://min.io) object store

## How to use

### Prerequisites

- [Docker](https://www.docker.com)

### Steps

Clone the repository

```sh
git clone https://github.com/kimfom01/minio-object-storage.git
```

On the terminal, navigate to `minio-object-storage` directory

```sh
cd minio-object-storage
```

Run the following

```sh
docker compose up
```

Add the flag `-d` or `--detach` to run in [detached mode](https://docs.docker.com/reference/cli/docker/compose/up)


> If you get the following error `Fatal glibc error: CPU does not support x86-64-v2` then use this image instead in the docker-compose.yml
> ```
> image: minio/minio:RELEASE.2023-11-01T01-57-10Z-cpuv1
> ```
