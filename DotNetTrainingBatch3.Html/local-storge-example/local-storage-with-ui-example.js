const tblBlog = "Tbl_Blog";
let _blogId="";

runBlog();

function runBlog() {

      readBlog();
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


function readBlog() {

    $('#tbodyData').html('');
    let htmlRow='';
    let lsBlog = [];
    lsBlog = getBlogs();
    for (let i = 0; i < lsBlog.length; i++) {
        const item = lsBlog[i];
        // console.log(item.Title);
        // console.log(item.Author);
        // console.log(item.Content);
        htmlRow+=`
        <tr>
        <td>
        <button type="button" class="btn btn-warning" onclick="editBlog('${item.Id}')">Edit</Button>
        <button type="button" class="btn btn-danger"  onclick="deleteBlog('${item.Id}')">Delete</Button>
        </td>
        <th scope="row">${i+1}</th>
        <td>${item.Title}</td>
        <td>${item.Author}</td>
        <td>${item.Content}</td>
        </tr>
        `;


    }


    $('#tbodyData').html(htmlRow);
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

    _blogId=item1.Id;
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
}

function deleteBlog(id) {

    let result=confirm('are you sure to delete?');
    if(!result) return;


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

    if(_blogId=="")
    {
        createBlog(title, author, content);
        alert("Saving Successful");
    }
    else
    {
        updateBlog(_blogId,title,author,content);
        alert("Updating Successful");
        _blogId="";
    }

    

    $('#Title').val('');
    $('#Author').val('');
    $('#Content').val('');

    $('#Title').focus();


    readBlog();
});