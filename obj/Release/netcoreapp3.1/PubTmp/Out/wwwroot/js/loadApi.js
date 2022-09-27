

async function getPage(page) {
	let response = await fetch(`https://ophim1.com/danh-sach/phim-moi-cap-nhat?page=${page}`);
	let data = await response.json()
	//console.log(data.pagination.totalPages);
	return data;
}

async function getTotalPages() {
    let response = await fetch(`https://ophim1.com/danh-sach/phim-moi-cap-nhat?page=`);
	let data = await response.json()
	//console.log(data.pagination.totalPages);
	for(var i = 1 ; i <= data.pagination.totalPages; i++)
	{
	    //var b = 10;	
		//console.log(b*i+1,b+(i*10));
		jsonObjToArray(i,i);
	}
}
getTotalPages()

async function jsonObjToArray(startPage, endPage) {
	let currentPage = startPage;
	let final = [];

	while(currentPage <= endPage) {
		const pageData = await getPage(currentPage);
		//console.log('adding page',currentPage);
		final.push(...pageData.items);
		currentPage++;
	  }
	// for(let i = 10; i >= startPage; i --){
	// 	const pageData = await getPage(currentPage);
	// 	  console.log('adding page');
	// 	final.push(...pageData.items);
	// }

	//console.log(final);
	//const map2 = new Map();

	/*final.forEach(object => {
		var action = "/phim/?slug=";
		$('#name').append('<ul class="ai"><li class="data visible"><a href="' + action + '' + object.slug + '">' + object.name + ' (' + object.origin_name + ')' + '</a></li></ul>');
		});*/
		//console.log(map2);

		// final.forEach(object =>{
		// 	$('#myList').append('<li class="data visible"><a href="'+object.slug+'">'+object.name+'</a></li>');
		// });


	//show(final);


}
	  
	// for(var i = 0 ; i <= 690 / 9 - 8; i++)
	// {
	//    var b = 10;
	//    //console.log(b*i+1,b+(i*10));
	//   getNumberPage(b*i+1,b+(i*10));
  
	// }
	// for(var i = 1 ; i <= endPage2; i++)
	// {
	//     //var b = 10;	
	// 	//console.log(b*i+1,b+(i*10));
	// 	getNumberPage(i,i);
	// }
	// getNumberPage(1,687);


// function show(final){
// 		let tab = 
// 	        `<tr style"with:100%">
// 	          <th>Name</th>
// 	         </tr>`;
		
// 	    // Loop to access all rows
// 	    for (let r of final) {
// 				tab += `<tr> 
// 						<td class="listItem">${r.name} </td>       
// 					</tr>`;
// 		}
	
// 		document.getElementById("data").innerHTML = tab;
// }

