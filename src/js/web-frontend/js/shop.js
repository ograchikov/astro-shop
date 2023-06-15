document.addEventListener("keydown", handleKeyPress);
document.addEventListener("DOMContentLoaded", function () {
	renderProducts();
	updateCartButtonStyle();
});


function handleKeyPress(event) {
	if (event.key === "ArrowLeft") {
		navigateProductGallery(-1);
	} else if (event.key === "ArrowRight") {
		navigateProductGallery(1);
	} else if (event.key === "Escape") {
		closeProductPopup();
		closeCartPopup();
	}
}

const products = [
	{ id: 1, name: "AI Art 1", price: 10 },
	{ id: 2, name: "AI Art 2", price: 30 },
	{ id: 3, name: "AI Art 3", price: 30 },
	{ id: 4, name: "AI Art 4", price: 30 },
	{ id: 5, name: "AI Art 5", price: 30 },
	{ id: 6, name: "AI Art 6", price: 30 },
	{ id: 7, name: "AI Art 7", price: 30 },
	{ id: 8, name: "AI Art 8", price: 30 },
	{ id: 10, name: "AI Art 10", price: 30 },
	{ id: 11, name: "AI Art 11", price: 30 },
	{ id: 12, name: "AI Art 12", price: 30 },
	{ id: 13, name: "AI Art 13", price: 30 },
	{ id: 14, name: "AI Art 14", price: 30 },
	{ id: 15, name: "AI Art 15", price: 20 },
	{ id: 16, name: "AI Art 16", price: 20 },
	{ id: 18, name: "AI Art 18", price: 25 },
	{ id: 19, name: "AI Art 19", price: 25 },
	{ id: 20, name: "AI Art 20", price: 25 },
	{ id: 21, name: "AI Art 21", price: 25 },
	{ id: 23, name: "AI Art 23", price: 200 },
	{ id: 24, name: "AI Art 24", price: 150 },
	{ id: 25, name: "AI Art 25", price: 300 }
];

const cart = [];

function renderProducts() {
	const productList = document.getElementById("product-list");
	products.forEach((product) => {
		const li = document.createElement("li");
		li.className = "product-card";
		li.setAttribute("product-id", product.id);

		const img = document.createElement("img");
		img.src = `images/${product.id.toString().padStart(2, '0')}.png`;
		img.alt = product.name;
		img.addEventListener("click", () => openProductPopup(product.id));
		li.appendChild(img);

		const name = document.createElement("p");
		name.textContent = product.name;
		name.setAttribute("name", "product-name");
		li.appendChild(name);

		const price = document.createElement("p");
		price.textContent = `$${product.price}`;
		price.setAttribute("name", "product-price");
		li.appendChild(price);

		const button = document.createElement("button");
		button.textContent = "Add to cart";
		button.setAttribute("name", "add-to-cart");
		button.addEventListener("click", () => addToCart(product));
		li.appendChild(button);

		productList.appendChild(li);
	});
}

function openProductPopup(productId) {
	const product = products.find((p) => p.id === productId);
	const popupOverlay = document.createElement("div");
	popupOverlay.className = "product-popup-overlay overlay";
	popupOverlay.addEventListener("click", closeProductPopup);

	const popupContainer = document.createElement("div");
	popupContainer.className = "product-popup-container";
	popupContainer.addEventListener("click", (event) => event.stopPropagation());

	const popupImage = document.createElement("img");
	popupImage.className = "product-popup-image";
	popupImage.src = `images/${product.id.toString().padStart(2, '0')}.png`;
	popupImage.alt = product.name;

	const popupLeftArrow = document.createElement("button");
	popupLeftArrow.className = "product-popup-arrow left";
	popupLeftArrow.innerHTML = "&#10094;";
	popupLeftArrow.addEventListener("click", navigateProductGallery.bind(null, -1));

	const popupRightArrow = document.createElement("button");
	popupRightArrow.className = "product-popup-arrow right";
	popupRightArrow.innerHTML = "&#10095;";
	popupRightArrow.addEventListener("click", navigateProductGallery.bind(null, 1));

	document.body.appendChild(popupOverlay);
	popupOverlay.appendChild(popupContainer);
	popupContainer.appendChild(popupImage);
	popupContainer.appendChild(popupLeftArrow);
	popupContainer.appendChild(popupRightArrow);
}

function closeProductPopup() {
	const popupOverlay = document.querySelector(".product-popup-overlay");
	document.body.removeChild(popupOverlay);
}

function navigateProductGallery(direction) {
	const popupImage = document.querySelector(".product-popup-image");
	const currentProductId = parseInt(popupImage.src.split("/").pop().split(".")[0]);
	const currentIndex = products.findIndex((p) => p.id === currentProductId);
	const newIndex = (currentIndex + direction + products.length) % products.length;
	const newProduct = products[newIndex];
	popupImage.src = `images/${newProduct.id.toString().padStart(2, '0')}.png`;
	popupImage.alt = newProduct.name;
}

function addToCart(product) {
	cart.push(product);
	renderCart();
	updateCartButtonStyle();
}

function updateCartButtonStyle() {
	const cartButton = document.getElementById("cart-button");

	// Check if there are items in the cart
	if (cart.length > 0) {
		cartButton.style.border = "2px solid lime";
		cartButton.style.fontWeight = "bold";
	} else {
		// Reset the style if there are no items in the cart
		cartButton.style.border = "";
		cartButton.style.fontWeight = "";
	}
}
