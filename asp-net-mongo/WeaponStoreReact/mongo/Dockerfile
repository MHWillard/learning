# Use the official MongoDB Community Server image
FROM mongodb/mongodb-community-server:latest

WORKDIR /app
RUN mkdir -p /app/ItemsData
COPY ./ItemsData /app/ItemsData

# Expose the default MongoDB port
EXPOSE 27017

# Optional: Set environment variables for initial database setup
# ENV MONGO_INITDB_ROOT_USERNAME=root
# ENV MONGO_INITDB_ROOT_PASSWORD=example
# ENV MONGO_INITDB_DATABASE=mydatabase

# Optional: Copy initialization scripts
# COPY mongo-init.js /docker-entrypoint-initdb.d/
CMD ["mongod", "--dbpath", "'/app/ItemsData'"]