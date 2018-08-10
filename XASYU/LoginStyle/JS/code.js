function checkNULL() {//判断是否为空和验证码的有效性
    //以下代码判断是否为空
    var userName = document.getElementById("tbxUserName").value;
    var userPwd = document.getElementById("tbxPassword").value;
    var userCode = document.getElementById("tbxuserCode").value;
    if (userName.length <= 0) {
        alert("请输入用户名!");
        return false;
    }
    if (userPwd.length <= 0) {
        alert("请输入用户名!");
        return false;
    }
    //以下代码判断验证码是否相等
    var inputCode = document.getElementById("tbxuserCode").value.toUpperCase();
    var codeToUp = code.toUpperCase();
    if (inputCode.length <= 0) {
        alert("请输入验证码！");
        return false;
    }
    else if (inputCode != codeToUp) {
        alert("验证码输入错误！");
        createCode();
        return false;
    }
}

function checkNULL_NEW() {//判断是否为空和验证码的有效性
    //以下代码判断是否为空
    var companyName = document.getElementById("tbxcompanyName").value;
    var zzjgdm = document.getElementById("tbxZZJGDM").value;
    var userCode = document.getElementById("tbxuserCode").value;
    if (companyName.length <= 0 && zzjgdm.length<=0) {
        alert("请输入查询条件!");
        return false;
    }
   
    //以下代码判断验证码是否相等
    var inputCode = document.getElementById("tbxuserCode").value.toUpperCase();
    var codeToUp = code.toUpperCase();
    if (inputCode.length <= 0) {
        alert("请输入验证码！");
        return false;
    }
    else if (inputCode != codeToUp) {
        alert("验证码输入错误！");
        createCode();
        return false;
    }
}

var code; //在全局 定义验证码      
function createCode() {
    code = "";
    var codeLength = 6;//验证码的长度      
    var checkCode = document.getElementById("tbxcheckCode");
    checkCode.value = "";
    var selectChar = new Array(1, 2, 3, 4, 5, 6, 7, 8, 9, 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z', 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'J', 'K', 'L', 'M', 'N', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z');

    for (var i = 0; i < codeLength; i++) {
        var charIndex = Math.floor(Math.random() * 60);
        code += selectChar[charIndex];
    }
    if (code.length != codeLength) {
        createCode();
    }
    checkCode.value = code;
}
function formReset() {
    document.getElementById("form1").reset();
    createCode();//重置重新产生验证码
}