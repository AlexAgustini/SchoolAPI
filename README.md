
# .NET Core Web Api School API 

School api project developed with .NET Core for learning purposes. 
The project was deployed in an AWS EC2 instance inside a Docker container, connecting to a SQL Server running in AWS RDS. 

To access the project: http://ec2-50-16-178-178.compute-1.amazonaws.com:5000/swagger

The API endpoints are secured with a JWT Token authentication system. To generate a token, create an user(allowed anonymously), and login with that same user in the auth/login endpoint, which will return you a valid token.
