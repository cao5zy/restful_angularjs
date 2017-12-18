# 服务器、WebApp 开发参考
## 前言

这个开源项目即是为了能够记录踩过的坑，也是为了未来的项目实践作参考。避免今后在同样的问题上重复投入，将更多的时间留给未来更有价值的事情。



## 技术要点

1. AngularJs 2
2. WCF Restful Service
3. 跨域问题
4. 依赖注入应用(Autofac)
5. 服务端接口扩展
6. TT
8. EntityFramework
9. RESTFul
10. 函数式编程
11. Linq
12. Microsoft Sql Server
13. IIS
14. 自动化部署
15. 日志配置
16. 数据加载展示层
17. WCF 部署到IIS中的问题

## 项目文件夹介绍

|- frontend \# 前端代码  
|- backend \# 后端服务器代码  
|- tools \# 辅助工具脚本  
|- dbscript \# 数据库初始化脚本和Schema定义

## AngularJs 2

通过cli来创建项目以及创建组件，Service等。[参考](https://github.com/angular/angular-cli)

### 常用命令

1. ng new 项目名称 \# 创建项目
2. ng serve \# 启动项目 
3. ng build \# 编译项目
4. ng generate component 组件名称 \# 创建组件，并将其添加到app.module.ts内

### 技术要点

#### IE兼容

[参考Stackoverflow](https://stackoverflow.com/questions/35140718/angular-2-4-not-working-in-ie11)  
[参考AngularJs 的Brower support](https://angular.io/guide/browser-support)  
注释掉src/polyfills.ts中的如下代码  
	import 'core-js/es6/symbol';
	import 'core-js/es6/object';
	import 'core-js/es6/function';
	import 'core-js/es6/parse-int';
	import 'core-js/es6/parse-float';
	import 'core-js/es6/number';
	import 'core-js/es6/math';
	import 'core-js/es6/string';
	import 'core-js/es6/date';
	import 'core-js/es6/array';
	import 'core-js/es6/regexp';
	import 'core-js/es6/map';
	import 'core-js/es6/weak-map';
	import 'core-js/es6/set';


#### Observable
[参考AngularJs2Rxjs](http://www.angulartypescript.com/angular-2-rxjs-observable/)
添加引用  
	import { Observable } from 'rxjs/Observable';
	import { Observer } from 'rxjs/Observer';
在http通信中使用  
	post(urn: string, param: any): Observable<any>{

		return new Observable<any>((observer: Observer<any>)=>{
	    this.http.post(this.buildUrl(urn),param)
	    .subscribe((res)=>{
	        observer.next(res);
	    });
	});
在template中使用  
	<tr *ngFor="let obj of this.memberList | **async**; let i = index;" (click)="selectUser(obj, template)">
		<td>{{obj.UserId}}</td>
		<td>{{obj.Role.Name}}</td>
		<td>{{obj.Username}}</td>
		<td>{{obj.FirstName}}</td>
		<td>{{obj.LastName}}</td>
		<td>{{obj.Mobile}}</td>
		<td>{{obj.Email}}</td>
		<td>{{obj.DateOfBirthStr}}</td>
		<td><button type="button" class="btn btn-danger" (click)="deleteUser(obj.UserId, $event)"><span class="glyphicon glyphicon-search"></span></button></td>
	</tr>
#### Route
通过使用Route，能够通过Url来加载对应的component  
添加引用  
	import { RouterModule, Routes } from '@angular/router';
定义route  
	const appRoutes: Routes = [
	  { path: 'members', component: MembersComponent },
	  { path: 'roles', component: RolesComponent},
	  { path: '', redirectTo: '/members', pathMatch: "full"}
	];
导入route  
	@NgModule({
	  declarations: [
	  ...
	  ],
	  imports: [
	  	...
	    **RouterModule.forRoot(appRoutes)**
	  ],
	  bootstrap: [AppComponent],
	  providers: [...]
	})
其它注意事项  
1. base设置  
route要正常工作，必须依赖于index.html的base设置  
	<base href="/"/>
特别是将AngularJs2的站点放在网站的文件夹而不是根目录时，这个地址必须设置正确，否则route不能正常工作  
2. router-outlet  
router-outlet是AngularJs2用来显示route内容的占位符，通过放在app.component.html中（根component中）。  
#### ServiceProvider

#### 样式使用





[markdown 语法](https://equation85.github.io/blog/markdown-examples/)
