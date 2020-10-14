var modal = document.querySelector("#modal"),
	modalOverlay = document.querySelector("#modal-overlay"),
	closeButton = document.querySelector("#close-button"),
	openButton = document.querySelector("#open-button");

//closeButtons.forEach(it => it.classList.toggle("closed"));

function handler(event) {
	modal.classList.toggle("closed");
	modalOverlay.classList.toggle("closed");
	console.log(event);
}

closeButton.addEventListener("click", handler);

openButton.addEventListener("click", handler);


console.log(closeButton);
console.log(openButton);