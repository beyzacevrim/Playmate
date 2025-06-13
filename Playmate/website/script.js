const bar = document.getElementById('bar');
const close = document.getElementById('close');
const nav = document.getElementById('navbar');

if (bar) {
    bar.addEventListener('click', () => {
        nav.classList.add('active');
    })
}

if (close) {
    close.addEventListener('click', () => {
        nav.classList.remove('active');
    })
}

document.addEventListener("DOMContentLoaded", function () {
    const favoriteButtons = document.querySelectorAll(".toggle-favorite");

    favoriteButtons.forEach(button => {
        button.addEventListener("click", function (e) {
            e.preventDefault(); 
            const icon = this.querySelector(".heart-icon");
            icon.classList.toggle("favorited");
        });
    });

   
    const profileSidebarLinks = document.querySelectorAll('.profile-sidebar ul li a');
    const profileSections = document.querySelectorAll('.profile-main-content .profile-section');

    /
    function showSectionFromHash() {
        const hash = window.location.hash;
        let targetSectionId = '#user-info-section'; 

        if (hash && document.querySelector(hash)) {
            targetSectionId = hash;
        }

        profileSections.forEach(section => {
            if ('#' + section.id === targetSectionId) {
                section.classList.add('active-section');
            } else {
                section.classList.remove('active-section');
            }
        });

        profileSidebarLinks.forEach(link => {
            if (link.getAttribute('href') === targetSectionId) {
                link.classList.add('active-link');
            } else {
                link.classList.remove('active-link');
            }
        });
    }

    
    showSectionFromHash();
    window.addEventListener('hashchange', showSectionFromHash);
    const addFavoriteUrl = '@Url.Action("AddFavorite", "Favoriler")';
    const removeFavoriteUrl = '@Url.Action("RemoveFavorite", "Favoriler")';
    const requestVerificationToken = document.querySelector('input[name="__RequestVerificationToken"]')?.value;
    const initialFavoritedProductIds = @Html.Raw(Json.Encode(ViewBag.FavoritedProductIds ?? new List < int > ()));


    profileSidebarLinks.forEach(link => {
        link.addEventListener('click', function (e) {
            e.preventDefault();

            const targetSectionId = this.getAttribute('href');

            profileSidebarLinks.forEach(item => item.classList.remove('active-link'));
            this.classList.add('active-link');


            profileSections.forEach(section => section.classList.remove('active-section'));

            document.querySelector(targetSectionId).classList.add('active-section');
            window.location.hash = targetSectionId;
        });
    });

    function handleLogin(event) {
        event.preventDefault(); // Sayfanýn otomatik yenilenmesini engeller

       
        const email = document.getElementById("email").value;
        const password = document.getElementById("password").value;

        if (email && password) {
            // Giriþ baþarýlýysa profile sayfasýna yönlendir
            window.location.href = "User.html";
        } else {
            alert("Lütfen tüm alanlarý doldurun!");
        }
    }

    const favoriteButtons = document.querySelectorAll('#product1 .pro .toggle-favorite');

    favoriteButtons.forEach(button => {
        button.addEventListener('click', function (event) {
            event.preventDefault(); 

            const productCard = this.closest('.pro'); // Ürün kartýný bul
            const productId = productCard.dataset.productId; // data-product-id deðerini al
            const heartIcon = this.querySelector('.heart-icon'); // Kalp simgesini bul

            // Kalp simgesinin mevcut durumunu kontrol et
            const isFavorited = heartIcon.classList.contains('favorited');

            if (isFavorited) {
                // Zaten favoride ise, favoriden çýkar
                removeProductFromFavorites(productId, heartIcon);
            } else {
                // Favoride deðilse, favoriye ekle
                addProductToFavorites(productId, heartIcon);
            }
        });
    });

    });
