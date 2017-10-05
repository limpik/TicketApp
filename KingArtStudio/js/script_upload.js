(function($){
// Автор: Тимур Камаев, http://wp-kama.ru/

// Глобальная переменная куда будут располагаться данные файлов. С не будем работать
var files;

// Вешаем функцию на событие
// Получим данные файлов и добавим их в переменную
$('input[type=file]').change(function(){
	files = this.files;
});


// Вешаем функцию ан событие click и отправляем AJAX запрос с данными файлов
$('.submit.button').click(function( event ){
	event.stopPropagation(); // Остановка происходящего
	event.preventDefault();  // Полная остановка происходящего

	// Содадим данные формы и добавим в них данные файлов из files
	var data = new FormData();
	$.each( files, function( key, value ){
		data.append( key, value );
	});

	// Отправляем запрос
	$.ajax({
		url: './upload_files.php?uploadfiles',
		type: 'POST',
		data: data,
		cache: false,
		dataType: 'json',
		processData: false, // Не обрабатываем файлы (Don't process the files)
		contentType: false, // Так jQuery скажет серверу что это строковой запрос
		success: function( respond, textStatus, jqXHR ){
			// Если все ОК
			if( typeof respond.error === 'undefined' ){
				// Файлы успешно загружены, делаем что нибудь здесь
                 
				// выведем пути к загруженным файлам в блок '.ajax-respond'
				
				var html = '<h5>Файл успешно загружен</h5>';
				
				$('.ajax-respond').html( html );
			}
			else{
				console.log('ОШИБКИ ОТВЕТА сервера: ' + respond.error );
			}
		},
		error: function( jqXHR, textStatus, errorThrown ){
			console.log('ОШИБКИ AJAX запроса: ' + textStatus );
		}
	});
	
});


})(jQuery)