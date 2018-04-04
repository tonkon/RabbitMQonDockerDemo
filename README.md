This is a demo to use RabbitMQ container. The Receive and Send are written by .Net Core. The host of docker is Ubuntu

## 1.Create a RabbitMQ container 
<pre><code>
cd RabbitMQ
chmod +x CreateRabbitMQ.sh
CreateRabbitMQ.sh
</code></pre>
Or create it directly from docker run
<pre><code>
docker run -d --hostname demo-rabbit --name demo-rabbit -p 5672:5672 -p 15672:15672 rabbitmq:3.7.4-management  
</code></pre>

## 2.Get IP Address of the RabbitMQ container
<pre><code>
docker inspect demo-rabbit
</code></pre>

## 3.Add rabbitMQ IPAddress to Env (suppose the IP is 172.17.0.2)
<pre><code>
vim ~/.bashrc
</code></pre>
Append RABBITMQ_HOST='172.17.0.2' to .bashrc file and then make it effective
<pre><code>
source ~/.bashrc
</code></pre>

## 3.Open a shell to build and run receive container(Replace the IPAddress of RabbitMQ)
<pre><code>
cd Receive
chmod +x build.sh
build.sh
docker run -it --rm -e RABBITMQ_HOST='172.17.0.2' demo/receive 
</code></pre>

## 4.Open another shell to build and run send container(Replace the IPAddress of RabbitMQ)
<pre><code>
cd Send
chmod +x build.sh
build.sh
docker run -it --rm -e RABBITMQ_HOST='172.17.0.2' demo/send 
</code></pre>
