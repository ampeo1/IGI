"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established

connection.on("ReceiveMessage", function (message, user) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var div = document.createElement("div");
    var now = new Date(new Date()).toLocaleString("ru", { timezone: "Belarus/Minsk" });;
    div.style.margin = 10 + "px";
    div.style.backgroundColor = "#7E6AD2";
    div.style.color = "#FFFC6F";
    div.style.textAlign = "center";
    div.innerHTML = "<span>" + user + "</span><br />" + "<span>" + msg + "</span><br />" + "<span>" + now + "</span>";
    document.getElementById("listMessage").appendChild(div);
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("AddresseUsername").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", message, user)
});

connection.start();
