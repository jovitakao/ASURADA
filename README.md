# What's ASURADA
A web-based self-serving SQL client. You can directly query with this lightweight tool with a Docker container.

# Why do you need ASURADA
- Database performance troubleshooting
- Daily database monitoring
- You don't want to install various SQL client packages on your own box. 

# Features
- Fancy UI based on bootstrap admin
- SQL Query
- Query Result Export (csv,Excel,text)
- Command Execution (e.g. exec stored procedure)
- Database Monitoring 
- Slow Query Trace

# Supported Data Sources
- PostgreSQL
- MySQL/MariaDB
- SQL Server
- Oracle [TBD]
- Hive
- Impala

# To Get Started
```
docker pull nissl/tbd
docker run -ti -e CONNECTION_STRING=... -p 5000:5000 nissl/tbd
```
