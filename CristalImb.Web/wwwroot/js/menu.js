$(document).ready(function () {
	$('.menu li:has(ul)').click(function (e) {
		e.preventDefault();

		if ($(this).hasClass('activado')) {
			$(this).removeClass('activado');
			$(this).children('ul').slideUp();
		} else {
			$('.menu li ul').slideUp();
			$('.menu li').removeClass('activado');
			$(this).addClass('activado');
			$(this).children('ul').slideDown();
		}
	});

	$('.btn-menu').click(function () {
		$('.contenedor-menu .menu').slideToggle();
	});

	$(window).resize(function () {
		if ($(document).width() > 450) {
			$('.contenedor-menu .menu').css({ 'display': 'block' });
		}

		if ($(document).width() < 450) {
			$('.contenedor-menu .menu').css({ 'display': 'none' });
			$('.menu li ul').slideUp();
			$('.menu li').removeClass('activado');
		}
	});

	$('.menu li ul li a').click(function () {
		window.location.href = $(this).attr("href");
	});
});


$("#number").on({
	"focus": function (event) {
		$(event.target).select();
	},
	"keyup": function (event) {
		$(event.target).val(function (index, value) {
			return value.replace(/\D/g, "")
				.replace(/([0-9])([0-9]{3})$/, '$1.$2')
				.replace(/\B(?=(\d{3})+(?!\d)\.?)/g, ",");
		});
    }
});