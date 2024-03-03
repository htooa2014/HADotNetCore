const tblBlog = "Tbl_Blog";
let _blogId = "";
let _alertOption = 1;   // 1 - Normal , 2 - SweetAlert , 3 - Notiflix

runBlog();

function runBlog() {

    readBlog();

    //generateSampleData();


    // createBlog('title','author','content');
    // editBlog("63be0c56-d54b-48be-940e-735c42f84b32");
    // editBlog("63be0c56-d54b-48be-940e-735c42f84b321111");
    // const  id=prompt("Enter id");
    // deleteBlog(id);
    // const  id=prompt("Enter id");
    // const title=prompt("Enter Title");
    // const author=prompt("Enter Autor");
    // const content=prompt("Enter Content");
    // updateBlog(id,title,author,content);

}

function generateSampleData() {
    for (var i = 0; i < 200; i++) {
        let number = i + 1;
        createBlog("Title" + number, "Autor" + number, `Content${number}`);
    }
}

function readBlog() {

    if ($.fn.DataTable.isDataTable('#blogTable')) {
        $('#blogTable').DataTable().destroy();
    }
    $('#tbodyData').html('');
    let htmlRow = '';
    let lsBlog = [];
    lsBlog = getBlogs();
    for (let i = 0; i < lsBlog.length; i++) {
        const item = lsBlog[i];
        // console.log(item.Title);
        // console.log(item.Author);
        // console.log(item.Content);
        htmlRow += `
        <tr>
        <td>
        <button type="button" class="btn btn-warning" onclick="editBlog('${item.Id}')">Edit</Button>
        <button type="button" class="btn btn-danger"  onclick="deleteBlog('${item.Id}')">Delete</Button>
        </td>
        <th scope="row">${i + 1}</th>
        <td>${item.Title}</td>
        <td>${item.Author}</td>
        <td>${item.Content}</td>
        </tr>
        `;


    }


    $('#tbodyData').html(htmlRow);

    new DataTable('#blogTable');
}


function editBlog(id) {
    var lsBlog = getBlogs();
    var item = lsBlog.filter(x => x.Id == id);
    if (item.length == 0) {
        console.log('No Data found.');
        return;
    }
    let item1 = item[0];
    // console.log(item1.Title);
    // console.log(item1.Author);
    // console.log(item1.Content);

    $('#Title').val(item1.Title);
    $('#Author').val(item1.Author);
    $('#Content').val(item1.Content);

    _blogId = item1.Id;
}

function updateBlog(id, title, author, content) {
    let lstBlog = getBlogs();
    var item = lstBlog.filter(x => x.Id === id);
    if (item.length === 0) {
        console.log('No Data found.');
        return;
    }

    let index = lstBlog.findIndex(x => x.Id === id);
    lstBlog[index] = {
        Id: id,
        Title: title,
        Author: author,
        Content: content
    }

    setLocalStorage(lstBlog);

    readBlog();

}

function createBlog(title, author, content) {


    var lsBlog = getBlogs();

    const blog = {
        Id: uuidv4(),
        Title: title,
        Author: author,
        Content: content
    };

    lsBlog.push(blog);

    setLocalStorage(lsBlog);

    readBlog();
}

function deleteBlog(id) {

    if (_alertOption === 1) {
        let result = confirm('are you sure to delete?');
        if (!result) return;

        Notiflix.Block.circle('#frm1');
        setTimeout(() => {
            DeleteBlogAndShowBlogList(id);
            Notiflix.Block.remove('#frm1');
        }, 3000);

    }
    else if (_alertOption === 2) {
        Swal.fire({
            title: "Confirm?",
            text: "Are you sure to delete",
            icon: "question",
            showCancelButton: true,
            confirmButtonText: "Yes"
        }).then((result) => {
            if (result.isConfirmed) {

                Notiflix.Block.circle('#frm1');
                setTimeout(() => {
                    DeleteBlogAndShowBlogList(id);
                    Notiflix.Block.remove('#frm1');
                }, 3000);
            }
        });
    }
    else if (_alertOption === 3) {
        Notiflix.Confirm.show(
            'Confirm',
            'Are you sure to delete',
            'Yes',
            'No',
            function okCb() {

                Notiflix.Block.circle('#frm1');
                setTimeout(() => {
                    DeleteBlogAndShowBlogList(id);
                    Notiflix.Block.remove('#frm1');
                }, 3000);


            },
            function cancelCb() {

            },
            {
            },
        );
    }





}
function getBlogs() {
    let lstBlogs = [];
    let blogStr = localStorage.getItem(tblBlog);
    if (blogStr != null) {
        lstBlogs = JSON.parse(blogStr);
    }
    return lstBlogs;
}


function setLocalStorage(blogs) {
    let jsonStr = JSON.stringify(blogs);
    localStorage.setItem(tblBlog, jsonStr);
}

function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
        (c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
    );
}

$('#btnSave').click(function () {
    const title = $('#Title').val();
    const author = $('#Author').val();
    const content = $('#Content').val();

    if (_blogId == "") {
        Notiflix.Loading.circle();
        setTimeout(() => {
            createBlog(title, author, content);
            Notiflix.Loading.remove();
            showMessage("Saving Successful");
        }, 3000);

    }
    else {
        Notiflix.Loading.circle();
        setTimeout(() => {
            updateBlog(_blogId, title, author, content);
            Notiflix.Loading.remove();
            showMessage("Updating Successful");
            _blogId = "";
        }, 3000);

    }



    $('#Title').val('');
    $('#Author').val('');
    $('#Content').val('');

    $('#Title').focus();


    readBlog();
});


function showMessage(message) {
    if (_alertOption === 1) {
        alert(message);
    }
    else if (_alertOption === 2) {
        Swal.fire({
            title: "Success",
            text: message,
            icon: "success"
        });
    }
    else if (_alertOption === 3) {
        //  Notiflix.Notify.success(message);
        Notiflix.Report.success(
            'Success',
            message,
            'Okay',
        );
    }

}


function DeleteBlogAndShowBlogList(id) {
    var lsBlog = getBlogs();
    var item = lsBlog.filter(x => x.Id === id);
    if (item.length == 0) {
        console.log('No Data found.');
        return;
    }

    var item2 = lsBlog.filter(x => x.Id != id);
    setLocalStorage(item2);

    readBlog();
}