const tblBlog="Tbl_Blog";
runBlog();

function runBlog()
{

  //  readBlog();
   // createBlog('title','author','content');
  // editBlog("63be0c56-d54b-48be-940e-735c42f84b32");
  // editBlog("63be0c56-d54b-48be-940e-735c42f84b321111");
// const  id=prompt("Enter id");
// deleteBlog(id);
const  id=prompt("Enter id");
const title=prompt("Enter Title");
const author=prompt("Enter Autor");
const content=prompt("Enter Content");
updateBlog(id,title,author,content);

}


function readBlog()
{
    let lsBlog=[];
     lsBlog=getBlogs();
    for(let i=0;i<lsBlog.length;i++)
    {
        const item=lsBlog[i];
        console.log(item.Title);
        console.log(item.Author);
        console.log(item.Content);
    }
}


function editBlog(id)
{
    var lsBlog=getBlogs();
    var item=lsBlog.filter(x=>x.Id==id);
    if(item.length==0) {
        console.log('No Data found.');
        return;
    }
    let item1=item[0];
    console.log(item1.Title);
    console.log(item1.Author);
    console.log(item1.Content);
}

function updateBlog(id, title, author, content)
{
    let lstBlog=getBlogs();
    var item=lstBlog.filter(x=>x.Id===id);
    if(item.length===0)
    {
        console.log('No Data found.');
        return;
    }

    let index=lstBlog.findIndex(x=>x.Id===id);
    lstBlog[index]={
    Id: id,
    Title: title,
    Author:author,
    Content:content
    }

    setLocalStorage(lstBlog);

}

function createBlog(title,author,content){
   

    var lsBlog=getBlogs();
    
const blog ={
    Id: uuidv4(),
    Title: title,
    Author:author,
    Content:content
};

lsBlog.push(blog);

setLocalStorage(item2);
}

function deleteBlog(id)
{
    var lsBlog=getBlogs();
    var item=lsBlog.filter(x=>x.Id===id);
    if(item.length==0) {
        console.log('No Data found.');
        return;
    }

    var item2=lsBlog.filter(x=>x.Id!=id);
    setLocalStorage(item2);
}
function getBlogs(){
    let lstBlogs=[];
    let blogStr= localStorage.getItem(tblBlog);
    if(blogStr!=null)
    {
        lstBlogs=JSON.parse(blogStr);
    }
    return lstBlogs;
}


function setLocalStorage(blogs)
{
    let jsonStr=JSON.stringify(blogs);
    localStorage.setItem(tblBlog,jsonStr);
}

function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
      (c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
    );
  }