# Fifthweek API

## Environment setup

1.  Open the following file:

        ~/Documents/IISExpress/config/applicationhost.config

2.  Paste the following line below the existing `<binding>` element:

        <binding protocol="https" bindingInformation=":44301:10.211.55.3" />

3.  Add the following environmental variables:

        BROWSER_STACK_ACCESS_KEY=<password>
        BROWSER_STACK_USERNAME=<email>
