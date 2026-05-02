$(document).ready(function () {
    function initializeProductSlider() {
        // Initialize main product image slider - matching active.js configuration
        if ($('.product-large-slider').length && !$('.product-large-slider').hasClass('slick-initialized')) {
            $('.product-large-slider').slick({
                fade: true,
                arrows: false,
                asNavFor: '.pro-nav'
            });
        }

        // Initialize product thumbnail slider - matching active.js configuration
        if ($('.pro-nav').length && !$('.pro-nav').hasClass('slick-initialized')) {
            $('.pro-nav').slick({
                slidesToShow: 4,
                asNavFor: '.product-large-slider',
                arrows: false,
                focusOnSelect: true
            });
        }

        // Initialize image zoom effect
        if ($('.img-zoom').length) {
            $('.img-zoom').zoom();
        }
    }

    $(document).on("click", ".quickViewIcon", function (e) {
        e.preventDefault();
        let url = $(this).closest('a').attr("href");
        fetch(url)
            .then((response) => response.text())
            .then((data) => {
                // Destroy existing sliders if they exist
                if ($('.product-large-slider').hasClass('slick-initialized')) {
                    $('.product-large-slider').slick('unslick');
                }
                if ($('.pro-nav').hasClass('slick-initialized')) {
                    $('.pro-nav').slick('unslick');
                }

                // Insert new content
                $("#quick_view .modal-dialog").html(data);

                // Initialize new sliders
                initializeProductSlider();

                // Show modal
                $("#quick_view").modal('show');
            })
            .catch((error) => console.error('Error:', error));
    });

    $(document).on("click", ".quick-view-btn", function (e) {
        e.preventDefault();
        let productId = $(this).data("id");
        let url = "/Product/ProductModal?id=" + productId;
        fetch(url)
            .then((response) => response.text())
            .then((data) => {
                // Destroy existing sliders if they exist
                if ($('.product-large-slider').hasClass('slick-initialized')) {
                    $('.product-large-slider').slick('unslick');
                }
                if ($('.pro-nav').hasClass('slick-initialized')) {
                    $('.pro-nav').slick('unslick');
                }

                // Insert new content
                $("#quick_view .modal-dialog").html(data);

                // Initialize new sliders
                initializeProductSlider();

                // Show modal
                $("#quick_view").modal('show');
            })
            .catch((error) => console.error('Error:', error));
    });

    // Reinitialize sliders when modal is shown (Bootstrap event)
    $(document).on('show.bs.modal', '#quick_view', function (e) {
        setTimeout(function () {
            initializeProductSlider();
        }, 100);
    });

    // Quantity increase/decrease handler
    $(document).on("click", ".qtybtn", function () {
        let $input = $(this).closest('.pro-qty').find('input');
        let qty = parseInt($input.val());

        if ($(this).hasClass('inc')) {
            $input.val(qty + 1);
        } else if ($(this).hasClass('dec')) {
            if (qty > 1) {
                $input.val(qty - 1);
            }
        }
    });


    $(.addbasket).on("click", function (e) {
        e.preventDefault();
        // Handle add to cart functionality
        let url = $(this).data("url");
        fetch(url)
            .then((response) => response.json())
            .then((data) => {
                $(".minicart-item-wrapper").append(html);
            })
    });
});