# Use Node.js 18 for building the Angular app
FROM node:18.19.0 AS build

# Define o diretório de trabalho no container
WORKDIR /app

# Copia o projeto Angular para o container
COPY . ./

# Copy package.json and package-lock.json to install dependencies
COPY package.json package-lock.json ./

# Install dependencies
RUN npm install

# Copy the entire Angular project to the container
COPY . ./

# Build the Angular app
RUN npm run build

# Use Nginx to serve the Angular app
FROM nginx:1.21.6-alpine

# Copy the built Angular app from the previous stage
COPY --from=build /app/dist/front-angular/browser /usr/share/nginx/html

# Copy the custom Nginx configuration file to the container
COPY nginx.conf /etc/nginx/conf.d/default.conf

# Expose port 80
EXPOSE 80

# Start Nginx
CMD ["nginx", "-g", "daemon off;"]

