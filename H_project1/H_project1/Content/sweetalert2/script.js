

function Comments() {
	swal({
		title: 'نظر خود را ثبت کنید.',
		  
		  html:
		    '<div class="form-horizontal" role="form">' +

			   '<div class="form-group">'+
			      
			      '<label for="firstname" class="col-sm-12 control-label">نام و نام خانوادگی :</label>' +
			      '<div class="col-sm-12">'+
			         '<input type="text" class="form-control" id="firstname" placeholder="نام و نام خانوادگی خود را وارد کنید">' +
			      '</div>' +
			      
			   '</div>' +
			   
			   '<div class="form-group">' +
			      
			      '<label for="lastname" class="col-sm-12 control-label">ایمیل :</label>' +	
			      '<div class="col-sm-12">' +
			         '<input type="email" class="form-control" id="email" placeholder="ایمیل خود را وارد کنید">' +
			     ' </div>' +
			     							
			   '</div>' +

			   '<div class="form-group">' +
			       '<label class="col-sm-12 control-label" for="">متن نظر :</label>' +
			       '<div class="col-sm-12">' +
			       		'<textarea class="form-control" rows="4" id="comment1"></textarea>' +
			       ' </div>' +
			   '</div>' +

			'</div>' ,
		  // input: 'email',
		  
		  confirmButtonText: 'ثبت نظر',
		  showLoaderOnConfirm: true,
		  showCancelButton: true,
		  cancelButtonColor: null,
		  cancelButtonClass: 'btn-danger',

		  preConfirm: function () {
		  	var value=true;
		    return new Promise(function (resolve, reject) {
		        setTimeout(function () {
		            var name = $('#firstname').val();
		            var email = $('#email').val();
		            var comment1 = $('#comment1').val();
		            $.ajax({
		                url: '/home/Comment',
		                type: 'POST',
		                datatype: 'json',
		                data: { name: name, email: email, comment2: comment1 }
                        
		            }).done(function (error) {
		                if(error==0)
		                {
                            resolve()
		                }
		                else if(error==1)
		                {
		                    reject('&nbsp;&nbsp; نظر شما ثبت نشد لطفا مجدد تلاش کنید ')
                           
		                }
		                else if(error==2)
		                {
		                    reject('&nbsp;&nbsp;  لطفا تمام فیلد ها را کامل کنید  ')
		                }
		                else if(error==3)
		                {
		                    reject('&nbsp;&nbsp;  ایمیل وارد شده نامعتبر است ')

		                }
		                
		            })
		      
		      }, 1000)
		    })
		  },
		  allowOutsideClick: false
		}).then(function () {
			swal({
			    type: 'success',
			    title: 'انجام شد .',
			     html: 'نظر شما با موفقیت ثبت شد و بعد از تایید مدیریت نمایش داده خواهد شد.' 
			})
			
		});
};