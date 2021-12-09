FROM flyway/flyway:latest

WORKDIR /flyway
COPY ./wait-for-it.sh wait-for-it.sh

USER root
RUN chmod +x wait-for-it.sh