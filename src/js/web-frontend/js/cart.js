const cartOverlay = document.getElementById("cart-overlay");
const cartButton = document.getElementById("cart-button");
const cartPopup = document.getElementById("cart-popup");
const cartPopupContent = document.getElementById("cart-popup");
let isCartOpen = false;

window.addEventListener("DOMContentLoaded", closeCartPopup);
document.getElementById("checkout-button").addEventListener("click", handleCheckout);
document.addEventListener("keydown", handleKeyPress);
document.addEventListener("click", handleOutsideClick);
cartButton.addEventListener("click", toggleCartPopup);

renderCart();

function handleKeyPress(event) {
	if (event.key === "Escape") {
		closeCartPopup();
	}
}

function handleOutsideClick(event) {
	if (!cartPopupContent.contains(event.target) && event.target !== cartButton) {
		closeCartPopup();
	}
}

function toggleCartPopup() {
	cartOverlay.classList.toggle("open");
}

function closeCartPopup() {
	cartPopup.classList.remove("open");
	cartOverlay.classList.remove("open");
}

function renderCart() {
	const cartList = document.getElementById("cart-list");
	cartList.innerHTML = ""; // Clear existing cart display
	cart.forEach((item) => {
		const li = document.createElement("li");
		li.className = "product-card";
		li.textContent = `${item.name} - ${item.price}`;

		const img = document.createElement("img");
		img.src = `images/${item.id.toString().padStart(2, '0')}.png`;
		img.alt = item.name;
		li.appendChild(img);

		const removeButton = document.createElement("button");
		removeButton.textContent = "Remove";
		removeButton.addEventListener("click", (event) => removeFromCart(event, item));
		li.appendChild(removeButton);

		cartList.appendChild(li);
	});
}

function removeFromCart(event, item) {
	event.stopPropagation();
	const index = cart.findIndex((cartItem) => cartItem.id === item.id);
	if (index !== -1) {
		cart.splice(index, 1);
		renderCart();
	}
	updateCartButtonStyle();
}

function handleCheckout() {
	alert(`Total: ${cart.reduce((sum, product) => sum + product.price, 0)}`);
	cart.length = 0;
	renderCart();
	closeCartPopup();
	updateCartButtonStyle();
}