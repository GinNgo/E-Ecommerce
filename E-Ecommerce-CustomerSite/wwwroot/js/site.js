// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

jQuery(function () {
    jQuery(".khoisanpham").slick({
        dots: false,
        infinite: false,
        speed: 300,
        slidesToShow: 5,
        slidesToScroll: 1,
        responsive: [
            {
                breakpoint: 1400,
                settings: {
                    slidesToShow: 3,
                    slidesToScroll: 1,
                    infinite: true,
                    dots: true
                }
            },
            {
                breakpoint: 600,
                settings: {
                    slidesToShow: 2,
                    slidesToScroll: 1
                }
            },
            {
                breakpoint: 480,
                settings: {
                    slidesToShow: 1,
                    slidesToScroll: 1
                }
            }
        ]
    });
    jQuery("#backtotop").click(function () {
        jQuery("html, body").animate({ scrollTop: 0 }, 400);
    });

    //hieu ung header va nut backtotop

    jQuery("#categories").hover(function () {

        jQuery(" .main-nav").css("display", "block");


    }
        , function () {

            jQuery(" .main-nav").css("display", "none");

        }
    );
    jQuery(window).scroll(function () {
        if (jQuery("body,html").scrollTop() > 650) {
            jQuery(".navbar").addClass("fixed-top");
            jQuery(".main-nav").css("display", "none");
            jQuery(".top-header").css("display", "none");

        }
        else {

            jQuery(".navbar").removeClass("fixed-top");
            jQuery(".top-header").css("display", "flex");
            jQuery("#categories").hover(function () {
                jQuery(" .main-nav").css("display", "none");
            });

        }
    });



    jQuery(window).scroll(function () {
        if (jQuery("body,html").scrollTop() > 500) {
            jQuery(".nutcuonlen").css("opacity", "1");
            jQuery(".nutcuonlen").css("visibility", "visible");
        }
        else {
            jQuery(".nutcuonlen").css("opacity", "0");
            jQuery(".nutcuonlen").css("visibility", "hidden");
        }
    });

    // header form dangnhap dangky
    jQuery(".nutdangnhap").click(function (e) {
        jQuery("ul.tabs .tab-dangnhap").addClass("active");
    });
    jQuery(".nutdangky").click(function (e) {
        jQuery("ul.tabs .tab-dangky").addClass("active");
    });

    jQuery("ul.tabs .tab-dangnhap").click(function (e) {
        jQuery("ul.tabs .tab-dangnhap").addClass("active");
        jQuery("ul.tabs .tab-dangky").removeClass("active");
    });

    jQuery("ul.tabs .tab-dangky").click(function (e) {
        jQuery("ul.tabs .tab-dangky").addClass("active");
        jQuery("ul.tabs .tab-dangnhap").removeClass("active");
    });

    // form dangnhap dangky 
    jQuery(".tab-dangky").click(function (e) {
        jQuery("#formdangnhap").removeClass("fade");
        jQuery("#formdangky").removeClass("fade");
        jQuery("#formdangnhap").modal("hide");
        jQuery("#formdangky").modal("show");
    });
    jQuery(".tab-dangnhap").click(function (e) {
        jQuery("#formdangnhap").removeClass("fade");
        jQuery("#formdangky").removeClass("fade");
        jQuery("#formdangky").modal("hide");
        jQuery("#formdangnhap").modal("show");
    });
    jQuery(".close").click(function (e) {
        jQuery(".modal").addClass("fade");
        jQuery("ul.tabs .tab-dangnhap").removeClass("active");
        jQuery("ul.tabs .tab-dangky").removeClass("active");
    });

    // thumb-img
    jQuery(".thumb-img.thumb1").addClass("vienvang");
    jQuery(".thumb-img").click(function (e) {
        jQuery(".product-image").attr("src", this.src);
    });

    jQuery(".thumb-img").click(function (e) {
        jQuery(".thumb-img:not(:hover)").removeClass("vienvang");
        jQuery(this).addClass("vienvang");
    });

    //btn-spin
    jQuery(".btn-inc").click(function (e) {
        var strval = jQuery(this).parent().prev().val();
        var val = parseInt(strval) + 1;
        jQuery(this).parent().prev().attr("value", val);
    });
    jQuery(".btn-dec").click(function (e) {
        var strval = jQuery(this).parent().next().val();
        var val = parseInt(strval) - 1;
        if (val < 1) {
            jQuery(this).parent().next().attr("value", 1);
        } else {
            jQuery(this).parent().next().attr("value", val);
        }
    });

    // gui danh gia
    jQuery(".formdanhgia").hide(200);
    jQuery(".vietdanhgia").click(function (e) {
        jQuery(".formdanhgia").toggle(200);
    });




    //rotate chevron
    jQuery("#step1contentid").on("show.bs.collapse", function () {
        jQuery(this).prev().addClass("active");
    })
    jQuery("#step1contentid").on("hide.bs.collapse", function () {
        jQuery(this).prev().removeClass("active");
    })
    jQuery("#step2contentid").on("show.bs.collapse", function () {
        jQuery(this).prev().addClass("active");
    })
    jQuery("#step2contentid").on("hide.bs.collapse", function () {
        jQuery(this).prev().removeClass("active");
    })
    jQuery("#step3contentid").on("show.bs.collapse", function () {
        jQuery(this).prev().addClass("active");
    })
    jQuery("#step3contentid").on("hide.bs.collapse", function () {
        jQuery(this).prev().removeClass("active");
    })

    // nut btn-shopping-without-signup
    jQuery("#step1contentid").collapse("show");
    jQuery(".btn-shopping-without-signup").click(function (e) {
        jQuery("#step1contentid").collapse("hide");
        jQuery("#step2contentid").collapse("show");
    });

    // validate
    //jQuery("#form-signup").validate({
    //    rules: {
    //        name: {
    //            required: true,
    //        },
    //        phone: {
    //            required: true,
    //            minlength: 8
    //        },
    //        password: {
    //            required: true,
    //            minlength: 6
    //        },
    //        confirm_password: {
    //            required: true,
    //            minlength: 6,
    //            equalTo: "#inputPassword"
    //        },
    //        email: {
    //            required: true,
    //            email: true
    //        }
    //    },
    //    messages: {
    //        name: {
    //            required: "Vui lòng nhập họ và tên",
    //        },
    //        phone: {
    //            required: "Vui lòng nhập số điện thoại",
    //            minlength: "Số máy quý khách vừa nhập là số không có thực"
    //        },
    //        password: {
    //            required: "Vui lòng nhập mật khẩu",
    //            minlength: "Vui lòng nhập ít nhất 6 kí tự"
    //        },
    //        confirm_password: {
    //            required: "Vui lòng nhập lại mật khẩu",
    //            minlength: "Vui lòng nhập ít nhất 6 kí tự",
    //            equalTo: "Mật khẩu không trùng"
    //        },
    //        email: {
    //            required: "Vui lòng nhập email",
    //            minlength: "Email không hợp lệ",
    //            email: "Vui lòng nhập email",
    //        }
    //    }
    //});

    //jQuery("#form-signin").validate({
    //    rules: {
    //        password: {
    //            required: true,
    //            minlength: 6
    //        },
    //        email: {
    //            required: true,
    //            email: true
    //        }
    //    },
    //    messages: {
    //        password: {
    //            required: "Vui lòng nhập mật khẩu",
    //            minlength: "Vui lòng nhập ít nhất 6 kí tự"
    //        },
    //        email: {
    //            required: "Vui lòng nhập email",
    //            minlength: "Email không hợp lệ",
    //            email: "Vui lòng nhập email",
    //        }
    //    }
    //});

    //jQuery("#form-signup-cart").validate({
    //    rules: {
    //        name: {
    //            required: true,
    //        },
    //        phone: {
    //            required: true,
    //            minlength: 8
    //        },
    //        password: {
    //            required: true,
    //            minlength: 6
    //        },
    //        confirm_password: {
    //            required: true,
    //            minlength: 6,
    //            equalTo: "#inputPassword"
    //        },
    //        email: {
    //            required: true,
    //            email: true
    //        }
    //    },
    //    messages: {
    //        name: {
    //            required: "Vui lòng nhập họ và tên",
    //        },
    //        phone: {
    //            required: "Vui lòng nhập số điện thoại",
    //            minlength: "Số máy quý khách vừa nhập là số không có thực"
    //        },
    //        password: {
    //            required: "Vui lòng nhập mật khẩu",
    //            minlength: "Vui lòng nhập ít nhất 6 kí tự"
    //        },
    //        confirm_password: {
    //            required: "Vui lòng nhập lại mật khẩu",
    //            minlength: "Vui lòng nhập ít nhất 6 kí tự",
    //            equalTo: "Mật khẩu không trùng"
    //        },
    //        email: {
    //            required: "Vui lòng nhập email",
    //            minlength: "Email không hợp lệ",
    //            email: "Vui lòng nhập email",
    //        }
    //    }
    //});

    //jQuery("#form-signin-cart").validate({
    //    rules: {
    //        password: {
    //            required: true,
    //            minlength: 6
    //        },
    //        email: {
    //            required: true,
    //            email: true
    //        }
    //    },
    //    messages: {
    //        password: {
    //            required: "Vui lòng nhập mật khẩu",
    //            minlength: "Vui lòng nhập ít nhất 6 kí tự"
    //        },
    //        email: {
    //            required: "Vui lòng nhập email",
    //            minlength: "Email không hợp lệ",
    //            email: "Vui lòng nhập email",
    //        }
    //    }
    //});







    jQuery(".tag a").click(function (e) {
        var tacgia = jQuery(this).data("tacgia");

        if (tacgia == "all") {
            jQuery(".items .row").isotope({ filter: "*" })
        } else {
            jQuery(".items .row").isotope({ filter: tacgia });
        }
        return false;
    });

    jQuery(".thay-doi-mk").hide();
    jQuery("#changepass").click(function (e) {
        jQuery(".thay-doi-mk").toggle(200);
    });



});

jQuery(document).ready(function () {
    jQuery(".main-nav li").hover(function () {
        jQuery(".mask").css("display", "block");
    }, function () {
        jQuery(".mask").css("display", "none");
    }
    );
    // add to cart
    //#region add to cart
    let product =
    {
        id: jQuery(".nutmua").attr("id"),
        name: jQuery(".khoithongtin .ten").text(),
        tag: jQuery(".product-image").attr("src"),
        price: parseFloat(jQuery(".gia span.giamoi").text()),
        old_price: parseFloat(jQuery(".gia span.giacu").text()),
        inCart: 0
    }

    let carts = document.querySelector(".nutmua");
    if (carts) {

        carts.addEventListener("click", () => {

            cartNumbers(product);
            totalCost(product);
        })
    }

    function onLoadCartNumbers() {
        let productNumbers = localStorage.getItem("cartNumbers");
        if (productNumbers) {
            document.querySelector(".giohang .cart-amount").textContent = productNumbers;
        }
    }

    function cartNumbers(product) {

        let productNumbers = localStorage.getItem("cartNumbers");
        productNumbers = parseInt(productNumbers);

        if (productNumbers) {
            localStorage.setItem("cartNumbers", productNumbers + parseInt(jQuery(".soluongsp").val()));
            document.querySelector(".giohang .cart-amount").textContent = productNumbers + parseInt(jQuery(".soluongsp").val());
        } else {
            localStorage.setItem("cartNumbers", parseInt(jQuery(".soluongsp").val()));
            document.querySelector(".giohang .cart-amount").textContent = parseInt(jQuery(".soluongsp").val());
        }
        setItem(product);
    }

    function setItem(product) {
        let cartItems = localStorage.getItem("productsInCart");
        cartItems = JSON.parse(cartItems);
        if (cartItems != null) {
            if (cartItems[product.id] == undefined) {
                cartItems = {
                    ...cartItems,
                    [product.id]: product
                }
            }
            cartItems[product.id].inCart += parseInt(jQuery(".soluongsp").val());
        } else {
            product.inCart = parseInt(jQuery(".soluongsp").val());
            cartItems = {
                [product.id]: product
            }
        }

        localStorage.setItem("productsInCart", JSON.stringify(cartItems));
    }

    function totalCost(product) {
        let cartCost = localStorage.getItem("totalCost");

        if (cartCost != null) {
            cartCost = parseFloat(cartCost);
            localStorage.setItem("totalCost", cartCost + parseInt(jQuery(".soluongsp").val()) * product.price);
        } else {
            localStorage.setItem("totalCost", parseInt(jQuery(".soluongsp").val()) * product.price);
        }
    }
    //#endregion

    //#region displaycart 
    function displayCart() {

        let cartContent = document.querySelector(".cart-content");
        let cartCost = localStorage.getItem("totalCost");
        let productNumbers = localStorage.getItem("cartNumbers");

        let cartItems = localStorage.getItem("productsInCart");
        cartItems = JSON.parse(cartItems);
        console.log(cartItems.length)
        if (cartItems == null || cartItems.length==0) {

            jQuery(".cart-empty").removeClass("d-none");
            jQuery(".cart").addClass("d-none");
            jQuery(".cart-steps").addClass("d-none");
        }

        if (cartItems && cartContent && cartItems.length !== 0) {
      
            jQuery(".cart-empty").addClass("d-none");
            jQuery(".cart").removeClass("d-none");
            jQuery(".cart-steps").removeClass("d-none");

            cartContent.innerHTML = "";
            let i = 0;
            cartContent.innerHTML += `
            <h6 class="header-gio-hang">GIỎ HÀNG CỦA BẠN <span>(${productNumbers} sản phẩm)</span></h6>
            <div class="cart-list-items">
            `
            Object.values(cartItems).map(item => {

                cartContent.innerHTML += `
                    <div class="cart-item d-flex" >
                        <a href="product-item.html" class="img">
                            <img src="${item.tag}" class="img-fluid img-pro" alt="${item.tag}">
                        </a>
                        <div class="item-caption d-flex w-100">
                            <div class="item-info ml-3">
                                <a href="product-item.html" class="ten">${item.name}</a>
                                <div class="soluong d-flex">
                                    <div class="input-number input-group mb-3">
                                        <div class="input-group-prepend">
                                            <span class="input-group-text btn-spin btn-dec-cart "id=${item.id}>-</span>
                                        </div>
                                        <input type="text" value="${item.inCart}"   class="soluongsp  text-center">
                                        <div class="input-group-append">
                                            <span class="input-group-text btn-spin btn-inc-cart" id=${item.id}  >+</span>
                                        </div>    </div>
                                </div>
                            </div>
                            <div class="item-price ml-auto d-flex flex-column align-items-end">
                                <div class="giamoi">${parseFloat(item.price).toFixed(3)} ₫</div>
                                <div class="giacu">${parseFloat(item.old_price).toFixed(3)} ₫</div>
                                <span class="remove mt-auto" id=${item.id}><i class="far fa-trash-alt"></i></span>
                            </div>
                        </div>
                    </div>
                    <hr>
                `
                i++;
            })

            cartContent.innerHTML += `
            </div>

            <div class="row">
                <div class="col-md-3">
                    <a href="index.html" class="btn nutmuathem mb-3">Mua thêm</a>
                </div>
                <div class="col-md-5 offset-md-4">
                    <div class="tonggiatien">
                        <div class="group d-flex justify-content-between">
                            <p class="label">Tạm tính:</p>
                            <p class="tamtinh">${parseFloat(cartCost).toFixed(3)} ₫</p>
                        </div>
                        <div class="group d-flex justify-content-between">
                            <p class="label">Giảm giá:</p>
                            <p class="giamgia">0 ₫</p>
                        </div>
                        <div class="group d-flex justify-content-between">
                            <p class="label">Phí vận chuyển:</p>
                            <p class="phivanchuyen">0 ₫</p>
                        </div>
                        <div class="group d-flex justify-content-between">
                            <p class="label">Phí dịch vụ:</p>
                            <p class="phidicvu">0 ₫</p>
                        </div>
                        <div class="group d-flex justify-content-between align-items-center">
                            <strong class="text-uppercase">Tổng cộng:</strong>
                            <p class="tongcong">${parseFloat(cartCost).toFixed(3)} ₫</p>
                        </div>
                        <small class="note d-flex justify-content-end text-muted">
                            (Giá đã bao gồm VAT)
                        </small>
                    </div>
                </div>
            </div>
            `


        }
    }

    jQuery(".btn-checkout").click(function (e) {
        localStorage.clear();
        location.reload(true);
        alert("cảm ơn đã mua hàng");
    });

    onLoadCartNumbers();
    displayCart()
    //#endregion
    //#region btn-spin-cart
    jQuery(".btn-inc-cart").click(function (e) {
        let cartItems = localStorage.getItem("productsInCart");
        cartItems = JSON.parse(cartItems);
        let product = Object.values(cartItems).filter(cart => {
            if (cart.id === this.id) {
                return cart;
            }

        });
        var strval = jQuery(this).parent().prev().val();
        var val = parseInt(strval) + 1;
        jQuery(this).parent().prev().attr("value", val);
        cartNumbersInc(...product);
        totalCostInc(...product);
    });

    //Inc 
    function cartNumbersInc(product) {
        let productNumbers = localStorage.getItem("cartNumbers");
        productNumbers = parseInt(productNumbers);
        localStorage.setItem("cartNumbers", productNumbers + 1);
        document.querySelector(".giohang .cart-amount").textContent = productNumbers + 1;
        setItemInc(product);
    }
    function setItemInc(product) {
        let cartItems = localStorage.getItem("productsInCart");
        cartItems = JSON.parse(cartItems);
        cartItems[product.id].inCart += 1;
        localStorage.setItem("productsInCart", JSON.stringify(cartItems));
    }

    function totalCostInc(product) {
        let cartCost = localStorage.getItem("totalCost");
        cartCost = parseFloat(cartCost) + product.price;
        var cost = document.querySelector(".tongcong");
        cost.innerHTML = `${parseFloat(cartCost).toFixed(3)}₫`
        localStorage.setItem("totalCost", cartCost);
    }
    //#endregion
    //#region btn-decs-cart
    jQuery(".btn-dec-cart").click(function (e) {
        let cartItems = localStorage.getItem("productsInCart");
        cartItems = JSON.parse(cartItems);
        let product = Object.values(cartItems).filter(cart => {
            if (cart.id === this.id) {
                return cart;
            }
        });
        console.log(...product)
        var strval = jQuery(this).parent().next().val();
        var val = parseInt(strval) - 1;
        if (val < 1) {
            jQuery(this).parent().next().attr("value", 1);
            val = 1
        } else {
            jQuery(this).parent().next().attr("value", val);
        }
        cartNumbersDesc(...product, val);
        totalCostDesc(...product, strval);
    });
    //Desc 
    function cartNumbersDesc(product, val) {
        let productNumbers = localStorage.getItem("cartNumbers");
        productNumbers = parseInt(productNumbers);
        if (val > 1) {
            localStorage.setItem("cartNumbers", productNumbers - 1);
            document.querySelector(".giohang .cart-amount").textContent = productNumbers - 1;
        }


        setItemDesc(product, val);
    }
    function setItemDesc(product, val) {
        let cartItems = localStorage.getItem("productsInCart");
        cartItems = JSON.parse(cartItems);
        cartItems[product.id].inCart = val;
        localStorage.setItem("productsInCart", JSON.stringify(cartItems));
    }

    function totalCostDesc(product, strval) {

        if (strval > 1) {
            let cartCost = localStorage.getItem("totalCost");
            cartCost = parseFloat(cartCost) - product.price;
            var cost = document.querySelector(".tongcong");
            cost.innerHTML = `${parseFloat(cartCost).toFixed(3)}₫`
            localStorage.setItem("totalCost", cartCost);
        }

    }

    //#endregion
    //remove item
    jQuery(".remove").click(function (e) {

        let cartItems = localStorage.getItem("productsInCart");
        cartItems = JSON.parse(cartItems);

        cartItems = Object.values(cartItems).filter(e => {
            if (e.id == this.id) {
                let productNumbers = localStorage.getItem("cartNumbers");
                let cartCost = localStorage.getItem("totalCost");
                cartCost = cartCost - e.inCart * e.price;
                productNumbers = productNumbers - e.inCart;
                document.querySelector(".giohang .cart-amount").textContent = productNumbers;
                localStorage.setItem("totalCost", cartCost);
                localStorage.setItem("cartNumbers", productNumbers);
            }

            return e.id != this.id;
        });
        localStorage.setItem("productsInCart", JSON.stringify(cartItems));
      
        location.reload()


    });

}); 