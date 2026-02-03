FROM nginx:latest

# Remove configuração padrão
RUN rm /etc/nginx/conf.d/default.conf

# Copia configuração personalizada
COPY nginx.conf /etc/nginx/conf.d/default.conf

# Expõe porta 80
EXPOSE 80

# Mantém Nginx rodando em foreground
CMD ["nginx", "-g", "daemon off;"]
