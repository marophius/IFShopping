FROM nginx

COPY ApiGateways/nginx/nginx.local.conf /etc/nginx/nginx.conf
COPY ApiGateways/nginx/id-local.crt /etc/ssl/certs/id-local.ifshopping.com.crt
COPY ApiGateways/nginx/id-local.key /etc/ssl/private/id-local.ifshopping.com.key
COPY ApiGateways/nginx/api-local.crt /etc/ssl/certs/api-local.ifshopping.com.crt
COPY ApiGateways/nginx/api-local.key /etc/ssl/private/api-local.ifshopping.com.key