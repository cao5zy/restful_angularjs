export default {
	"username":{
		validexpression: "^[a-zA-Z\d]{5,10}$",
        blacklist: ["admin"]
	},
	"email":{
		validexpression: "^[\w!#$%&'*+/=?^_`{|}~-]+(?:\.[\w!#$%&'*+/=?^_`{|}~-]+)*@(?:[\w](?:[\w-]*[\w])?\.)+[\w](?:[\w-]*[\w])?$"
	},
	"mobile":{
		validexpression: "^\d{10}$"
	}
}
