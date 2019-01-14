# SimpleBank
Teste Processo Seletivo Indra



# Endpoints da api:

* (POST) /api/token 
(Gera token para acesso aos outros endpoints)

  **Parâmetros**:
  * Username    
  * Password
  
  *Username: usermaster, Password: 12345
   

* (GET) /api/accounts  (Lista contas e saldos. Passar token para autorização)

* (POST) /api/transfers  (Efetua uma transferência. Passar token para autorização)

  **Parâmetro Formato Json: (exemplo)**
```
{
	AccountSourceId: "926d8c2a-6c2a-4122-80ac-979aeab5ddc2",
	AcountDestinyId: "a5e7c859-1083-4db2-b4c4-17bdf90875fd",
	Value: 10
}
```
  
* Utilização do Token

  * O token deve ser passado via Http Header. Parâmetro: (Authorization: Bearer <<token value>>)



# Observações: 

Peço desculpas por existirem tantas falhas que violaram regras de DDD e Microservices. Infelizmente não tive tanto tempo para aplicar melhor os conceitos. :(

1. Entidade Conta deveria ser de outro subdominio
2. Mesmo que Conta não está representada como um subdominio, em TransferMoneyService, deveria ter uma transação de dados para não gerar inconsistencia de informação.
3. Usuarios também deveria estar em um outro subdominio, responsavel pelas contas que operam o sistema e até mesmo tendo controle de usuário via algum Geteway.
4. Validation para ficar mais elegante, desacoplado, reutilizavel e eficiente, poderia utilizar Specification Pattern para escrita das regras. Além disso, seria melhor o domínio ser validado por completo e fazer uma lista com as validações identificadas.
5. Alguns campos nas entidades deveriam ser readonly, mas para simplificar e não impactar o funcionamento do Entity, preferi deixar assim.
6. Gostaria de ter aplicado Eventos
7. Faltou Swagger para gerar uma visão melhor sobre os serviços da api
8. Deveria de ter utilizado async, mas já que não estou tão familiarizado com o .Net Core e não saberia dizer quais surpresas viriam, preferi não inventar moda. rsrs
