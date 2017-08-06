$(document).ready(function(){
		var selector = '.main-navigation li';

		$(selector).on('click', function(){
		    $(selector).removeClass('active');
		    $(this).addClass('active');
		});
});