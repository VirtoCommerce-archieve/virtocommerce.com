var VC = {

	mobileNav: function() {
		$('body').toggleClass('__opened');
	},

	mobilePhone: function() {
		$('.head-phone_num').toggleClass('opened');
	},

	changeCostumers: function() {
		if(window.innerWidth > 640) {
			$('.your-costumers .planet .satelite').off('mouseenter').on('mouseenter', function () {
				var name = $(this).prop('class').split(' ')[1];

				$('.your-costumers .planet').removeAttr('class').addClass('planet ' + name);
				$('.your-costumers .planet-content').removeClass('opened');
				$('.your-costumers .planet-content.' + name).addClass('opened');
			});
		}
		else {
			$('.your-costumers .planet .satelite').off('mouseenter');
			$('.your-costumers .planet .satelite').off('click').on('click', function () {
				var name = $(this).prop('class').split(' ')[1];

				$('.your-costumers .planet').removeAttr('class').addClass('planet ' + name);
				$('.your-costumers .planet-content').removeClass('opened');
				$('.your-costumers .planet-content.' + name).addClass('opened');

				/* Анимируем скролл экрана к контенту, если разрешение ниже 640 или равно ему */
				$('html, body').animate({scrollTop: $('.planet-info').offset().top}, 500);
			});
		}

		
	},

	changeJoined: function() {
		if(window.innerWidth > 800) {
			$('.join-info .joiner').off('mouseenter').on('mouseenter', function () {
				var name = $(this).prop('class').split(' ')[1];

				$('.join-dialog').removeAttr('class').addClass('join-dialog ' + name);
				$('.join-content').removeClass('opened');
				$('.join-content.' + name).addClass('opened');
			});
		}
		else {
			$('.join-info .joiner').off('mouseenter');
			$('.join-info .joiner').off('click').on('click', function () {
				var name = $(this).prop('class').split(' ')[1];

				$('.join-dialog').removeAttr('class').addClass('join-dialog ' + name);
				$('.join-content').removeClass('opened');
				$('.join-content.' + name).addClass('opened');
			});
		}
	}

}

$(function () {

	$('body').delegate('.mobile-btn', 'click', function () {
		VC.mobileNav();
	});

	$('.head-phone').off('click').on('click', function () {
		VC.mobilePhone();
	});

	$('.learn-link').on('click', function () {
		$(this).next().slideToggle(500);
	});

	/* Меняем описание для текущей планеты и красим ее в соотв. цвет */
	VC.changeCostumers();

	/* Меняем описание для блока Joined */
	VC.changeJoined();
	

	$(window).resize(function () {
		VC.changeCostumers();
		VC.changeJoined();
	});

});