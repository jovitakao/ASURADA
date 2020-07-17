# What's ASURADA
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2Ftonyqus%2FASURADA.svg?type=shield)](https://app.fossa.com/projects/git%2Bgithub.com%2Ftonyqus%2FASURADA?ref=badge_shield)

A web-based self-serving SQL client. You can directly query database with this lightweight tool.

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
- Druid
- Hive
- Impala

# To get started
```
docker pull nissl/tbd
docker run -ti -e CONNECTION_STRING=... -p 5000:5000 nissl/tbd
```


## License
[![FOSSA Status](https://app.fossa.com/api/projects/git%2Bgithub.com%2Ftonyqus%2FASURADA.svg?type=large)](https://app.fossa.com/projects/git%2Bgithub.com%2Ftonyqus%2FASURADA?ref=badge_large)