export default {
	"username":{
		validexpression: "^[a-zA-Z\\d]{5,10}$",
        blacklist: ["admin"],
        message: "Username should be 5 to 10 characters, with alphabetic characters and numbers"
	},
	"email":{
		validexpression: "^[\\w!#$%&'*+/=?^_`{|}~-]+(?:\\.[\\w!#$%&'*+/=?^_`{|}~-]+)*@(?:[\\w](?:[\\w-]*[\\w])?\\.)+[\\w](?:[\\w-]*[\\w])?$",
		message: "Email format is incorrect"
	},
	"mobile":{
		validexpression: "^\\d{10}$",
		message:"Should be exact 10 digits"
	}
}
