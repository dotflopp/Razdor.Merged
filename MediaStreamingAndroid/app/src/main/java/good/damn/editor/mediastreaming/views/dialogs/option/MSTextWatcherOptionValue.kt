package good.damn.editor.mediastreaming.views.dialogs.option

import android.text.Editable
import android.text.TextWatcher

class MSTextWatcherOptionValue
: MSOptionTextWatcher {

    override var model: MSMOption? = null

    override fun beforeTextChanged(
        s: CharSequence?,
        start: Int,
        count: Int,
        after: Int
    ) = Unit

    override fun onTextChanged(
        s: CharSequence?,
        start: Int,
        before: Int,
        count: Int
    ) {
        model?.value = s?.toString()
    }

    override fun afterTextChanged(
        s: Editable?
    ) = Unit

}