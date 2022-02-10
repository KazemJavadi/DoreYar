document.getElementById('Input_Card_Answer').hidden = true;


import BalloonEditor from '@ckeditor/ckeditor5-editor-balloon/src/ballooneditor';
import EssentialsPlugin from '@ckeditor/ckeditor5-essentials/src/essentials';
import UploadAdapterPlugin from '@ckeditor/ckeditor5-adapter-ckfinder/src/uploadadapter';
import AutoformatPlugin from '@ckeditor/ckeditor5-autoformat/src/autoformat';
import BoldPlugin from '@ckeditor/ckeditor5-basic-styles/src/bold';
import ItalicPlugin from '@ckeditor/ckeditor5-basic-styles/src/italic';
import BlockQuotePlugin from '@ckeditor/ckeditor5-block-quote/src/blockquote';
import HeadingPlugin from '@ckeditor/ckeditor5-heading/src/heading';
import ParagraphPlugin from '@ckeditor/ckeditor5-paragraph/src/paragraph';
import Alignment from '@ckeditor/ckeditor5-alignment/src/alignment';     // <--- ADDED
import List from '@ckeditor/ckeditor5-list/src/list';
import HorizontalLine from '@ckeditor/ckeditor5-horizontal-line/src/horizontalline';
import Highlight from '@ckeditor/ckeditor5-highlight/src/highlight';

import Bold from '@ckeditor/ckeditor5-basic-styles/src/bold';
import Italic from '@ckeditor/ckeditor5-basic-styles/src/italic';
import Underline from '@ckeditor/ckeditor5-basic-styles/src/underline';
import Strikethrough from '@ckeditor/ckeditor5-basic-styles/src/strikethrough';
import Code from '@ckeditor/ckeditor5-basic-styles/src/code';
import Subscript from '@ckeditor/ckeditor5-basic-styles/src/subscript';
import Superscript from '@ckeditor/ckeditor5-basic-styles/src/superscript';

BalloonEditor
    .create(document.querySelector('#editor'), {
        // The plugins are now passed directly to .create().
        plugins: [
            EssentialsPlugin,
            AutoformatPlugin,
            BoldPlugin,
            ItalicPlugin,
            BlockQuotePlugin,
            HeadingPlugin,
            ParagraphPlugin,
            UploadAdapterPlugin,
            Alignment,
            List,
            HorizontalLine,
            Highlight,
            Bold, Italic, Underline, Strikethrough, Code, Subscript, Superscript
        ],

        // So is the rest of the default configuration.
        toolbar: [
            'heading',
            'bold',
            'italic',
            'underline', 'strikethrough', 'code', 'subscript', 'superscript',
            'bulletedList',
            'numberedList',
            'blockQuote',
            'undo',
            'redo',
            `alignment`,
            'horizontalLine',
            'highlight'
        ],
        image: {
            toolbar: [
                'imageStyle:inline',
                'imageStyle:block',
                'imageStyle:side',
                '|',
                'toggleImageCaption',
                'imageTextAlternative'
            ]
        }
    })
    .then(editor => {
        console.log(editor);
    })
    .catch(error => {
        console.error(error);
    });

    //.create(document.querySelector('#editor'), {
    //    plugins: [Alignment],     // <--- MODIFIED
    //})
    //.then(editor => {
    //    console.log('Editor was initialized', editor);
    //})
    //.catch(error => {
    //    console.error(error.stack);
    //});

document.querySelector('#submit').addEventListener('click', () => {
    alert(document.getElementById('editor').innerHTML);
    document.getElementById('Input_Card_Answer').value = document.getElementById('editor').innerHTML;
}
);