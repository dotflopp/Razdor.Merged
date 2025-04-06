FROM node:22 AS builder
WORKDIR /front
# Copy all files from current directory to working dir in image
COPY . .
# install node modules and build assets
RUN npm i && npm run build

FROM nginx:alpine
WORKDIR /usr/share/nginx/html
# Remove default nginx static assets
RUN rm -rf ./*
# Copy static assets from builder stage
COPY --from=builder /front/dist .
# Containers run nginx with global directives and daemon off
ENTRYPOINT ["nginx", "-g", "daemon off;"]