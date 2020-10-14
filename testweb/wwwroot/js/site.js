var modal = document.querySelector("#modal"),
	modalOverlay = document.querySelector("#modal-overlay"),
	//closeButton = document.querySelector("#close-button"),
	//	openButton = document.querySelector("#open-button"),
	table = document.querySelector("#product-table"),
	cascadeDeleteBtn = document.querySelector("#cascadeDeleteBtn"),
	nonCascadeDeleteBtn = document.querySelector("#nonCascadeDeleteBtn");

//closeButtons.forEach(it => it.classList.toggle("closed"));
var elementId;

table.querySelectorAll("#open-button").forEach(it => it.addEventListener("click", handler));
modalOverlay.addEventListener("click", handler);

cascadeDeleteBtn.addEventListener("click", DeleteCascade);
nonCascadeDeleteBtn.addEventListener("click", handler);

function handler(event) {
	modal.classList.toggle("closed");
	modalOverlay.classList.toggle("closed");
	console.log(event.target);

	//console.log(event.target.value);
	elementId = event.target.getAttribute("value");
}

function DeleteCascade(event) {
	console.log("delete cascade");
	//let url = '?id=' + elementId + '&handler=DeleteType';
	let url = "/Types/Delete?id=" + elementId;
	// asp-page-handler="DeleteType" asp-route-id="elementId"
	/*elementId = -1;
	const formData = new FormData();
	formData.append('id', elementId);
	console.log(formData);

	let response = fetch(url, {
		method: 'POST',
		headers: {
			'Content-Type': 'application/json;charset=utf-8'
		},
		body: formData
	});*/

	fetch(url)
		.then((response) => {
			if (response.ok) {
				alert("Ветка успешно удалена");
			}
			else {
				alert("Ветку не удалось удалить");
			}

			location.reload();
		});
}


console.log(closeButton);
console.log(openButton);