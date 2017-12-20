# 安装指南
1. 安装必要组件
2. 初始化数据库
3. 配置部署应用程序

## 1. 安装必要组件
### 安装SQL Server Express
[下载安装Sql express 2014 server 和Sql Management Studio](https://www.microsoft.com/zh-CN/download/details.aspx?id=42299)
### 安装.net framework 4.5
[下载.net framework 4.5](https://www.microsoft.com/zh-CN/download/details.aspx?id=30653)   
### 安装Git
[下载git](https://git-scm.com/download/win)  
### 安装NodeJs 8.9.2
[下载NodeJs 8.9.2](https://nodejs.org/download/release/v8.9.2/)  
安装angular-cli  

    npm install @angular/cli@1.6.1 -g

最好安装上面指定版本，安装其它版本不敢保证在安装js库时能够顺利通过。  
### 安装配置IIS
[参考配置IIS](https://jingyan.baidu.com/article/fec4bce2398747f2618d8b88.html)  
网上有很多关于IIS的配置文章，在配置WCF的IIS环境的时候，除了确保“Application Development Features”全部被选择外，还应该确保“.NET Framework Advanced Services”/“WCF Services”中的“HTTP Activation”被勾选。  
[参考配置WCF](https://docs.microsoft.com/en-us/dotnet/framework/wcf/servicemodelreg-exe)：

	ServiceModelReg.exe -i

配置IIS访问数据库的identity：  
选择WCF服务对应的应用服务池，点击“Advanced Settings”，将"identity"中的选项改为Network Service。  

## 2. 初始化数据库

打开Sql Management Studio, 打开/dbscript/init.sql，点击执行，完成数据库的创建。  

在配置登录时，可以由多种方式，这里以使用windows user为例，login name为NETWORK SERVICE, user name为iis。  

## 3. 配置部署应用程序
### AngularJs 2的部署和配置
1. 运行git bash, 在c:/app下获取项目  
	
	cd c:/
	mkdir app
	cd app
	git clone https://github.com/cao5zy/restful_angularjs.git

2. 编译  

	cd frontend
	ng build

3. 将dist目录中的文件拷贝到IIS的站点目录下  
### WCF 应用的编译和配置
1. 在本地用VS2015编译UserService项目  
2. 更改web.config中的数据库连接字符串信息。但是，如果已经按照上面的方式配置了数据库的访问用户，这里就不用更改了  
3. 如果你需要的话，更改web.config中的日志输出目录，当前的配置为c:\temp\wcf.log，并配置c:\temp的IIS的Identity的访问权限
4. 如果AngularJs2的站点和WCF Service不是部署在同一站点下，还要配置allowedDomains，添加AngularJs2站点的地址，否则不能跨域访问  

上面的步骤看上去有点繁琐，因此Windows部署的automation正在编写中....





