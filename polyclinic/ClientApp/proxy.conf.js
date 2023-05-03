 const PROXY_CONFIG = [
   {
     context: [
       "/*",
     ],
     target: "https://localhost:7201", //АДРЕС СЕРВЕРА
     secure: false
   }
 ]

 module.exports = PROXY_CONFIG;
//Прокси нужен если мы не будем использовать адрес сервера из environments
