$("#contactForm").submit(function(event){
event.preventDefault();
submitForm();
});


function submitForm(){
// Переменные с данными из формы
var name = $("#name").val();
var email = $("#email").val();
var message = $("#message").val();
$.ajax({
type: "POST",
url: "services/mail.php",
data:  "&name="+ name + "&email="+ email + "&message="+ message,
success : function(text){
if(text == "success"){
formSuccess(); 
}
}
});
}
function  formSuccess(){
$( ".modal-footer").removeClass("hidden"); 
}


$(".tovar #this_a").delegate("a", "click", function() {
		var b = $(this).attr('title');

		$.ajax({
			type: "POST",
			url: "content2.php",
			data: "id="+b,
			success: function(data){
				$("#modal_tovar .mdl").html(data);
			}
		});
});











