$(function () {
    $('.js-delete-course').on("click", function () {
        let self = $(this);
        let idCourse = self.attr('id')

        if ($.isNumeric(idCourse)) {
            $.ajax({
                url: '/Course/Delete',
                type: 'POST',
                data: { id: idCourse },
                beforeSend: function () {
                    self.text('Processing...')
                },
                success: function (res) {
                    console.log('res', res)
                    self.text('Delete')
                    if (res) {
                        alert('Delete success')
                        $(`.row-course-${idCourse}`).hide()
                    } else {
                        alert(res)
                        return
                    }
                }
            })
        }
    })
})